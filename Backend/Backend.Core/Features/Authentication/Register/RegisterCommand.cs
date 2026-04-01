using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public sealed record RegisterCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

}
