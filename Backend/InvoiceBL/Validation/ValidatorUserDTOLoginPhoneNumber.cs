using FluentValidation;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorUserDTOLoginPhoneNumber : AbstractValidator<UserDTOLoginPhoneNumber>
    {
        public ValidatorUserDTOLoginPhoneNumber()
        {
            const string errorCode = "InvalidPhoneOrPassword";
            const string errorMessage = "Invalid Phone or Password";
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
            #region PhoneNumber Validation
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(?:\+?2|002)?01[0125][0-9]{8}$")
                .WithMessage(errorMessage).WithErrorCode(errorCode);
            #endregion

        }

    }
}
