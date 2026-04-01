using Backend.Application.Features.Authentication.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterCommand registerRequest);
    }
}
