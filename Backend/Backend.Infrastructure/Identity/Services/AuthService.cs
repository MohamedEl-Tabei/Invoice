using Backend.Application.Common.Contracts;
using Backend.Application.Common.Enums;
using Backend.Application.Common.Extensions;
using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Result;
using Backend.Infrastructure.Identity.Extensions;
using Backend.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Identity.Services
{
    public sealed class AuthService(UserManager<User> userManager, ISmsService smsService, IEmailService emailService,PhoneNumberTokenProvider<User> phoneNumberTokenProvider) : IAuthService
    {
        public async Task<BaseResult> RegisterAsync(RegisterRequest registerRequest)
        {
            #region Check Existing Email 
            var existingEmail = await userManager.IsEmailExistsAsync(registerRequest.Email);
            if (existingEmail) return ResultFactory.Failure(ErrorsType.Conflict, new List<string> { "Email already exists." });
            #endregion
            #region Check Existing Phone Number
            var existingPhoneNumber = await userManager.IsPhoneNumberExistsAsync(registerRequest.PhoneNumber);
            if (existingPhoneNumber) return ResultFactory.Failure(ErrorsType.Conflict, new List<string> { "Phone number already exists." });
            #endregion
            #region Create User
            var user = new User
            {
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                UserName = registerRequest.Name.CapitalizeFirstLetter(),
            };
            var result = await userManager.CreateAsync(user, registerRequest.Password);
            #endregion
            #region Validate Result
            if (!result.Succeeded) return ResultFactory.Failure(ErrorsType.BadRequest, result.Errors.Select(e => e.Description).ToList());
            #endregion

            #region Send Confirmation Email
            var tokenEmail = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await emailService.SendConfirmationAsync(user.Email, tokenEmail);
            #endregion
            #region Send Confirmation SMS
            var tokenSms = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
            await smsService.SendConfirmationAsync(user.PhoneNumber, tokenSms);
            #endregion

            return ResultFactory.Success<string>(user.Id);
        }
    }
}
