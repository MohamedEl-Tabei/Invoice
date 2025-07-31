using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
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

        public UserAppManager(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<string>> RegisterAsync(UserDTORegister userDTORegister)
        {
            var result = new Result<string>();

            var user = new UserApp()
            {
                Email = userDTORegister.Email,
                UserName = userDTORegister.Email,
                PhoneNumber = userDTORegister.PhoneNumber,
            };
            var userResult = await _userManager.CreateAsync(user, userDTORegister.Password);
            if (!userResult.Succeeded)
            {
                result.Errors = userResult.Errors.Select(x => new Error() { Message = x.Description, Code = x.Code }).ToList();
                return result;
            }
            result.Data = user.Id;
            return result;
        }
    }
}
