using Backend.Application.Common.Enums;
using Backend.Application.Common.Extensions;
using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Models;
using Backend.Application.Features.Authentication.Register;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Services
{
    public sealed class AuthService(UserManager<User> userManager) : IAuthService
    {
        public async Task<Result<string>> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = $"{registerDTO.FirstName.CapitalizeFirstLetter()} {registerDTO.LastName.CapitalizeFirstLetter()}"
            };
            var result = await userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded) return Result<string>.Success("User registered successfully.");
            else return Result<string>.Failure(ErrorsType.BadRequest, result.Errors.Select(e => e.Description).ToList());
        }
    }
}
