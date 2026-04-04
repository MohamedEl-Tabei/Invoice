using Backend.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public sealed record RegisterCommand : IRequest<BaseResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }


}
