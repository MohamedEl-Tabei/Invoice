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
        public async Task<Result<UserDTOAuthenticated>> RegisterAsync(UserDTORegister userDTORegister)
        {
            var result = new Result<UserDTOAuthenticated>();
            #region Check Email, UserName and Phone Are Unique
            var isUniqueUserName = await _unitOfWork._UserRepo.IsUniqueAsync(x => x.UserName == userDTORegister.UserName);
            var isUniquePhoneNumber = await _unitOfWork._UserRepo.IsUniqueAsync(x => x.PhoneNumber == userDTORegister.PhoneNumber);
            var isUniqueEmail = await _unitOfWork._UserRepo.IsUniqueAsync(x => x.Email == userDTORegister.Email);

            if (!isUniqueEmail) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.Email, userDTORegister.Email));
            if (!isUniquePhoneNumber) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.PhoneNumber, userDTORegister.PhoneNumber));
            if (!isUniqueUserName) result.Errors.Add(Utilities.GetUniqueStringDataError(UniqueProperties.UserName, userDTORegister.UserName));
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
            var RoleResult = await _userManager.AddToRoleAsync(user, userDTORegister.Role);
            if (!RoleResult.Succeeded)
            {
                result.Errors.AddRange(RoleResult.ToErrorList());
                return result;
            }

            #endregion
            result.Successed = true;
            #region Create Token
            var tokenConfig = new TokenDTOConfigurations()
            {
                Email = userDTORegister.Email,
                RememberMe = false,
                Role = userDTORegister.Role,
                UserId = user.Id
            };
            var token = _tokenManager.CreateToken(tokenConfig);
            #endregion
            result.Data = new UserDTOAuthenticated()
            {
                Token = token,
                UserName = user.UserName
            };
            return result;
        }
    }
}
