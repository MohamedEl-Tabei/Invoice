using Backend.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    internal static class RegisterMappingExtensions
    {
        public static RegisterRequest ToRegisterRequest(this RegisterCommand command)
        {
            return new RegisterRequest
            {
                Email = command.Email,
                Name = command.Name,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber
            };
        }

    }
}
