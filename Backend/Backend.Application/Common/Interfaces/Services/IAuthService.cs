using Backend.Application.Common.Models;
using Backend.Application.Features.Authentication.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<String>> RegisterAsync(RegisterDTO registerDTO);
    }
}
