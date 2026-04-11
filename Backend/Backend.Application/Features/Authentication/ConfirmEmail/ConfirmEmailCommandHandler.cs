using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Result.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(IAuthService authService) : IRequestHandler<ConfirmEmailCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            return await authService.ConfirmEmailAsync(request.ToConfirmEmailRequest());
        }
    }
}