using FluentValidation;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Validation;
using InvoiceDAL;
using InvoiceDAL.Constants;
using InvoiceDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Managers
{
    public class UserAppManager : IUserAppManager
    {
        private readonly ITokenManger _tokenManager;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UserDTORegister> _validatorUserDTORegister;

        public UserAppManager(ITokenManger tokenManger, UserManager<UserApp> userManager, IValidator<UserDTORegister> validatorUserDTORegister, IUnitOfWork unitOfWork)
        {
            _tokenManager = tokenManger;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _validatorUserDTORegister = validatorUserDTORegister;
        }

        public async Task<Result<UserDTOAuthenticated>> LoginWithEmailAsync(UserDTOLoginEmail userDTOLoginEmail)
        {
            var result = new Result<UserDTOAuthenticated>();
            var error = new Error()
            {
                Code = ErrorCodes.BadRequest,
                Message = "Invalid Email or Password",
                PropertyName = "Email or Password"
            };
            #region Find User By Email
            var user = await _userManager.FindByEmailAsync(userDTOLoginEmail.Email);
            if (user == null)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Check Password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userDTOLoginEmail.Password);
            if (!isPasswordValid)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Create Token
            var roles = await _userManager.GetRolesAsync(user);
            var tokenConfig = new TokenDTOConfigurations()
            {
                UserName = user.UserName,
                RememberMe = userDTOLoginEmail.RememberMe,
                Roles = roles,
                UserId = user.Id
            };
            var token = _tokenManager.CreateToken(tokenConfig);
            #endregion
            result.Data = new UserDTOAuthenticated()
            {
                Token = token,
                UserName = user.UserName,
                Roles = roles
            };
            result.Successed = true;
            return result;
        }

        public async Task<Result<UserDTOAuthenticated>> LoginWithPhoneNumberAsync(UserDTOLoginPhoneNumber userDTOLoginPhoneNumber)
        {
            var result = new Result<UserDTOAuthenticated>();
            var error = new Error()
            {
                Code = ErrorCodes.BadRequest,
                Message = "Invalid Phone Number or Password",
                PropertyName = "Phone Number or Password"
            };
            #region Find User By Phone Number
            var user = await _unitOfWork._UserRepo.FindByPhoneNumberAsync(userDTOLoginPhoneNumber.PhoneNumber);
            if (user == null)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Check Password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userDTOLoginPhoneNumber.Password);
            if (!isPasswordValid)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Create Token
            var roles = await _userManager.GetRolesAsync(user);
            var tokenConfig = new TokenDTOConfigurations()
            {
                UserName = user.UserName,
                RememberMe = userDTOLoginPhoneNumber.RememberMe,
                Roles = roles,
                UserId = user.Id
            };
            var token = _tokenManager.CreateToken(tokenConfig);
            #endregion
            result.Data = new UserDTOAuthenticated()
            {
                Token = token,
                UserName = user.UserName,
                Roles = roles
            };
            result.Successed = true;
            return result;
        }

        public async Task<Result<UserDTOAuthenticated>> LoginWithUserNameAsync(UserDTOLoginUserName userDTOLoginUserName)
        {
            var result = new Result<UserDTOAuthenticated>();
            var error = new Error()
            {
                Code = ErrorCodes.BadRequest,
                Message = "Invalid UserName or Password",
                PropertyName = "UserName or Password"
            };
            #region Find User By UserName
            var user = await _userManager.FindByNameAsync(userDTOLoginUserName.UserName);
            if (user == null)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Check Password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userDTOLoginUserName.Password);
            if (!isPasswordValid)
            {
                result.Errors.Add(error);
                return result;
            }
            #endregion
            #region Create Token
            var roles = await _userManager.GetRolesAsync(user);
            var tokenConfig = new TokenDTOConfigurations()
            {
                UserName = user.UserName,
                RememberMe = userDTOLoginUserName.RememberMe,
                Roles = roles,
                UserId = user.Id
            };
            var token = _tokenManager.CreateToken(tokenConfig);
            #endregion
            result.Data = new UserDTOAuthenticated()
            {
                Token = token,
                UserName = user.UserName,
                Roles = roles
            };
            result.Successed = true;
            return result;
        }

        public async Task<Result<UserDTOAuthenticated>> RegisterAsync(UserDTORegister userDTORegister)
        {
            var result = new Result<UserDTOAuthenticated>();
            #region Check Email, UserName and Phone Are Unique
            var isUsedUserName = await _unitOfWork._UserRepo.IsUsedAsync(x => x.UserName == userDTORegister.UserName);
            var isUsedPhoneNumber = await _unitOfWork._UserRepo.IsUsedAsync(x => x.PhoneNumber == userDTORegister.PhoneNumber);
            var isUsedEmail = await _unitOfWork._UserRepo.IsUsedAsync(x => x.Email == userDTORegister.Email);

            if (isUsedEmail) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.Email));
            if (isUsedPhoneNumber) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.PhoneNumber));
            if (isUsedUserName) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.UserName));
            if (result.Errors.Count > 0)
                return result;
            #endregion
            #region Validate User Data
            var validatorResult = _validatorUserDTORegister.Validate(userDTORegister);
            if (!validatorResult.IsValid)
            {
                result.Errors.AddRange(validatorResult.ToErrorList());
                return result;
            }
            #endregion
            #region Create User If Data Is Valid
            var user = new UserApp()
            {
                Email = userDTORegister.Email,
                UserName = userDTORegister.UserName,
                PhoneNumber = userDTORegister.PhoneNumber,
            };
            var userResult = await _userManager.CreateAsync(user, userDTORegister.Password);
            if (!userResult.Succeeded)
            {
                result.Errors.AddRange(userResult.ToErrorList());
                return result;
            }
            #endregion
            #region Add Role If User Created
            var RoleResult = await _userManager.AddToRoleAsync(user, AppRoles.Customer);
            if (!RoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                result.Errors.AddRange(RoleResult.ToErrorList());
                return result;
            }

            #endregion
            #region Create Token
            var tokenConfig = new TokenDTOConfigurations()
            {
                UserName = user.UserName,
                RememberMe = false,
                Roles = new List<string> { AppRoles.Customer },
                UserId = user.Id
            };
            var token = _tokenManager.CreateToken(tokenConfig);
            #endregion
            result.Successed = true;
            result.Data = new UserDTOAuthenticated()
            {
                Token = token,
                UserName = user.UserName,
                Roles = new List<string>() { AppRoles.Customer }
            };
            return result;
        }
    }
}
