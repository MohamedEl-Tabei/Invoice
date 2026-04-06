using Backend.Application.Common.Contracts;
using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Result.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public sealed class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            return await authService.RegisterAsync(command.ToRegisterRequest());
        }
    }
}
