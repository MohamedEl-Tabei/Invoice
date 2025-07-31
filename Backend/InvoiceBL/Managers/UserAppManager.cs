using FluentValidation;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Validation;
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
        private readonly UserManager<UserApp> _userManager;
        private readonly IValidator<UserDTORegister> _validatorUserDTORegister;

        public UserAppManager(UserManager<UserApp> userManager,IValidator<UserDTORegister> validatorUserDTORegister)
        {
            _userManager = userManager;
            _validatorUserDTORegister= validatorUserDTORegister;
        }
        public async Task<Result<string>> RegisterAsync(UserDTORegister userDTORegister)
        {
            var result = new Result<string>();
            var validatorResult=_validatorUserDTORegister.Validate(userDTORegister);
            if (!validatorResult.IsValid)
            {
                result.Errors = validatorResult.ToErrorList();
                return result;
            }
            var user = new UserApp()
            {
                Email = userDTORegister.Email,
                UserName = userDTORegister.Email,
                PhoneNumber = userDTORegister.PhoneNumber,
            };
            var userResult = await _userManager.CreateAsync(user, userDTORegister.Password);
            if (!userResult.Succeeded)
            {
                result.Errors = userResult.ToErrorList();
                return result;
            }
            result.Successed = true;
            result.Data = user.Id;
            return result;
        }
    }
}
