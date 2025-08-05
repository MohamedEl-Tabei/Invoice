using FluentValidation;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorUserDTOLoginEmail : AbstractValidator<UserDTOLoginEmail>
    {
        public ValidatorUserDTOLoginEmail()
        {
            const string errorCode = "InvalidEmailOrPassword";
            const string errorMessage = "Invalid Email or Password";
            #region Password validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage(errorMessage).WithErrorCode(errorCode)
                .Matches("^[^\\s]+$").WithMessage(errorMessage).WithErrorCode(errorCode)
                .Matches("[a-z]").WithMessage(errorMessage).WithErrorCode(errorCode)
                .Matches("[A-Z]").WithMessage(errorMessage).WithErrorCode(errorCode)
                .Matches(@"\d").WithMessage(errorMessage).WithErrorCode(errorCode)
                .Matches(@"[\W_]").WithMessage(errorMessage).WithErrorCode(errorCode);
            #endregion
            #region Email validation
            RuleFor(x => x.Email)
                     .NotEmpty().WithMessage("Email is required.")
                     .EmailAddress().WithMessage(errorMessage)
                     .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(errorMessage)
                     .WithErrorCode(errorCode);
            #endregion
            

        }
    }
}
