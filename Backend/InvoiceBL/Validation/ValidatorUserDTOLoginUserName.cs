using FluentValidation;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorUserDTOLoginUserName:AbstractValidator<UserDTOLoginUserName>
    {
        public ValidatorUserDTOLoginUserName()
        {
            const string errorCode = "InvalidUserNameOrPassword";
            const string errorMessage = "Invalid Name or Password";
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
            #region UserName Validation 
            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("UserName is required.")
                 .Length(3, 20).WithMessage(errorMessage)
                 .Matches(@"^[A-Za-z][A-Za-z0-9]{2,19}$").WithMessage(errorMessage);

            #endregion

        }
    }
}
