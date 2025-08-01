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
            //PhoneNumber Validation

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(?:\+?2|002)?01[0125][0-9]{8}$")
                .WithMessage("Invalid Phone number.");
            //Role Validation
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(x => AppRoles.Roles.Exists(y=>y==x.ToUpper()))
                .WithMessage("Invalid role.");

            // UserName Validation 
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.")
                .Length(3, 20);

            // Email validation
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email is required.")
                 .EmailAddress().WithMessage("Email is not valid.")
                 .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email is not valid.")
                 .WithErrorCode("EmailValidator");

            // Password validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.").WithErrorCode("InvalidPassword")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.").WithErrorCode("InvalidPassword")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.").WithErrorCode("InvalidPassword")
                .Matches(@"\d").WithMessage("Password must contain at least one number.").WithErrorCode("InvalidPassword")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.").WithErrorCode("InvalidPassword");

            // Confirm Password validation
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .MinimumLength(8).WithMessage("Confirm Password must be at least 8 characters long.").WithErrorCode("InvalidPassword")
                .Matches("[a-z]").WithMessage("Confirm Password must contain at least one lowercase letter.").WithErrorCode("InvalidPassword")
                .Matches("[A-Z]").WithMessage("Confirm Password must contain at least one uppercase letter.").WithErrorCode("InvalidPassword")
                .Matches(@"\d").WithMessage("Confirm Password must contain at least one number.").WithErrorCode("InvalidPassword")
                .Matches(@"[\W_]").WithMessage("Confirm Password must contain at least one special character.").WithErrorCode("InvalidPassword")
                .Equal(x => x.Password).WithMessage("Confirm Password must match Password.").WithErrorCode("InvalidPassword");

        }

    }
}
