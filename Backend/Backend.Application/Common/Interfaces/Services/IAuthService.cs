using Backend.Application.Common.Contracts;
using Backend.Application.Common.Result;
using Backend.Application.Features.Authentication.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<BaseResult> RegisterAsync(RegisterRequest registerRequest);
    }
}
