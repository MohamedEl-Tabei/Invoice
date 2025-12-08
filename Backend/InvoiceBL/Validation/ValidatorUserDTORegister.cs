using FluentValidation;
using FluentValidation.Results;
using InvoiceBL.DTOs;
using InvoiceDAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorUserDTORegister : AbstractValidator<UserDTORegister>
    {
        public ValidatorUserDTORegister()
        {
            #region PhoneNumber Validation
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(?:\+?2|002)?01[0125][0-9]{8}$")
                .WithMessage("Invalid Phone number.");
            #endregion
           
            #region UserName Validation 
            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("UserName is required.")
                 .Length(3, 20).WithMessage("UserName must be between 3 and 20 characters.")
                 .Matches(@"^[A-Za-z][A-Za-z0-9]{2,19}$").WithMessage("UserName must start with a letter and contain only letters and digits.");

            #endregion
            #region Email validation
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email is required.")
                 .EmailAddress().WithMessage("Email is not valid.")
                 .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email is not valid.")
                 .WithErrorCode("EmailValidator");
            #endregion
            #region Password validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.").WithErrorCode("InvalidPassword")
                .Matches("^[^\\s]+$").WithMessage("Password must not contain spaces.").WithErrorCode("InvalidPassword")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.").WithErrorCode("InvalidPassword")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.").WithErrorCode("InvalidPassword")
                .Matches(@"\d").WithMessage("Password must contain at least one number.").WithErrorCode("InvalidPassword")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.").WithErrorCode("InvalidPassword");
            #endregion
            #region Confirm Password validation
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .MinimumLength(8).WithMessage("Confirm Password must be at least 8 characters long.").WithErrorCode("InvalidPassword")
                .Matches("[a-z]").WithMessage("Confirm Password must contain at least one lowercase letter.").WithErrorCode("InvalidPassword")
                .Matches("[A-Z]").WithMessage("Confirm Password must contain at least one uppercase letter.").WithErrorCode("InvalidPassword")
                .Matches(@"\d").WithMessage("Confirm Password must contain at least one number.").WithErrorCode("InvalidPassword")
                .Matches(@"[\W_]").WithMessage("Confirm Password must contain at least one special character.").WithErrorCode("InvalidPassword")
                .Equal(x => x.Password).WithMessage("Confirm Password must match Password.").WithErrorCode("InvalidPassword");
            #endregion
        }

    }
}
