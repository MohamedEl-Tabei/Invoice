using Backend.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.ConfirmEmail
{
    public static class ConfirmEmailMappingExtensions
    {
        public static ConfirmEmailRequest ToConfirmEmailRequest(this ConfirmEmailCommand command) => new ConfirmEmailRequest()
        {
            Token = command.Token,
            UserId = command.UserId
        };
    }
}
