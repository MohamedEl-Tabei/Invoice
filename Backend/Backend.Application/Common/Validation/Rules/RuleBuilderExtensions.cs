using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Validation.Rules
{
    public static class RuleBuilderExtensions
    {
        /// <summary>
        /// Defines a set of validation rules to ensure that a string property represents a valid name, requiring it to
        /// be non-empty, within specified length limits, and composed only of letters.
        /// </summary>
        /// <remarks>This method applies multiple validation constraints, including non-emptiness, minimum
        /// and maximum length, and character restrictions, to help ensure that the property value is a valid name. The
        /// error messages use the provided property name for clarity in validation feedback.</remarks>
        /// <typeparam name="T">The type of the object containing the property to be validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder used to construct validation rules for the specified string property.</param>
        /// <param name="propertyName">The display name of the property being validated. Defaults to "Name" if not specified.</param>
        /// <returns>An options builder that enables further configuration of the validation rules for the property.</returns>
        public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName = "Name")
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{propertyName} is required.")
                .MinimumLength(3).WithMessage($"{propertyName} must be at least 2 characters long.")
                .MaximumLength(50).WithMessage($"{propertyName} must not exceed 20 characters.")
                .Matches(@"^[a-zA-Z]+$").WithMessage($"{propertyName} must contain only letters");
        }
        /// <summary>
        /// Defines a validation rule that ensures the specified string property is a valid email address.
        /// </summary>
        /// <remarks>The validation rule checks that the email address is not empty and matches a standard
        /// email format. Custom error messages are provided for both missing and invalid email addresses.</remarks>
        /// <typeparam name="T">The type of the object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder used to construct validation rules for a string property.</param>
        /// <returns>An options builder that can be used to further configure the email validation rule.</returns>
        public static IRuleBuilderOptions<T, string> IsEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Email is required.")
                .Matches(@"^(?!.*\.\.)(?!\.)(?!.*\.$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$").WithMessage("Invalid email format.");
        }
        /// <summary>
        /// Defines a validation rule that ensures the input string is a valid Egyptian phone number.
        /// </summary>
        /// <remarks>The validation rule requires the phone number to be non-empty and to match the
        /// Egyptian phone number format, which allows for an optional country code and enforces valid mobile
        /// prefixes.</remarks>
        /// <typeparam name="T">The type of the object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the Egyptian phone number validation rule is defined.</param>
        /// <returns>An options builder that can be used to further configure the validation rule.</returns>
        public static IRuleBuilderOptions<T, string> IsEgyptianPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(?:\+20|0)?1[0125]\d{8}$")
                .WithMessage("Invalid Egyptian phone number.");
        }
        /// <summary>
        /// Defines a set of validation rules to ensure that a string meets common password security requirements.
        /// </summary>
        /// <remarks>The validation enforces that the password is not empty, has a minimum length of 8
        /// characters, and includes at least one uppercase letter, one lowercase letter, one digit, and one special
        /// character.</remarks>
        /// <typeparam name="T">The type of the object being validated. Typically represents a model class containing the password property.</typeparam>
        /// <param name="ruleBuilder">The rule builder used to construct validation rules for the password property.</param>
        /// <returns>An options builder that enables further customization of the password validation rules.</returns>
        public static IRuleBuilderOptions<T, string> IsPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches(@"^\S+$")
                .WithMessage("Password must not contain spaces.")
                .Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter (A-Z).")
                .Matches(@"[a-z]")
                .WithMessage("Password must contain at least one lowercase letter (a-z).")
                .Matches(@"\d")
                .WithMessage("Password must contain at least one digit (0-9).")
                .Matches(@"[@$!%*?&]")
                .WithMessage("Password must contain at least one special character (@, $, !, %, *, ?, &).");


        }
    }
}
