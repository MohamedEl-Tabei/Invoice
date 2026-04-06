using Backend.Application.Common.Contracts;
using Backend.Application.Common.Errors.Codes;
using Backend.Application.Common.Errors.Factory;
using Backend.Application.Common.Extensions;
using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Result.Base;
using Backend.Application.Common.Result.Factory;
using Backend.Infrastructure.Identity.Extensions;
using Backend.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Identity.Services
{
    public sealed class AuthService(UserManager<User> userManager,  IEmailService emailService) : IAuthService
    {
        public async Task<BaseResult> RegisterAsync(RegisterRequest registerRequest)
        {
            #region Check Existing Email 
            var oldUser = await userManager.FindByEmailAsync(registerRequest.Email);
            if (oldUser is not null) return ResultFactory.DuplecatedFailure(ErrorFactory.Create(ErrorCodes.Duplicated,"Email"));
            #endregion

            #region Create User
            var user = new User
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Name.CapitalizeFirstLetter(),
            };
            var result = await userManager.CreateAsync(user, registerRequest.Password);
            #endregion
            #region Validate Result
            if (!result.Succeeded) return ResultFactory.ValidationFailure( result.Errors.Select(e => ErrorFactory.Create(e.Code,e.Description)).ToList());
            #endregion

            #region Send Confirmation Email
            var tokenEmail = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await emailService.SendConfirmationAsync(user.Email, tokenEmail);
            #endregion
            

            return ResultFactory.Success<string>(user.Id);
        }
    }
}
