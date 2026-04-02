using Backend.Application.Common.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public sealed class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand>
    {
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await authService.RegisterAsync(request);
        }
    }
}
