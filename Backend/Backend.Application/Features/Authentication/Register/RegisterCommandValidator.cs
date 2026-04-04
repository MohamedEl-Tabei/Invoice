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

            RuleFor(x => x.Name).IsName("User Name");
            RuleFor(x => x.Email).IsEmail();
            RuleFor(x => x.PhoneNumber).IsEgyptianPhoneNumber();
            RuleFor(x => x.Password).IsPassword();



        }
    }
}
