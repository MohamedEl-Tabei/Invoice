using Backend.Application.Common.Result.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.ConfirmEmail
{
    public class ConfirmEmailCommand:IRequest<BaseResult>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
