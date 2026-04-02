using Backend.Application.Common.Validation.Rules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {

            RuleFor(x => x.FirstName).IsName("First Name");
            RuleFor(x => x.LastName).IsName("Last Name");


        }
    }
}
