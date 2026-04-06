using Backend.Application.Common.Errors.Codes;
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
        /// be non-empty, between 3 and 50 characters in length, and composed only of letters, numbers, or underscores.
        /// </summary>
        /// <remarks>Use this extension method with FluentValidation to enforce consistent naming
        /// conventions on string properties, such as user names or identifiers. The method applies multiple constraints
        /// and customizes error messages using the provided property name.</remarks>
        /// <typeparam name="T">The type of the object containing the property to be validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder used to construct validation rules for the specified string property.</param>
        /// <param name="propertyName">The display name of the property being validated. Defaults to "Name" if not specified.</param>
        /// <returns>An options builder that can be used to further configure the validation rules for the property.</returns>
        public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName = "Name")
        {
            return ruleBuilder
                .NotEmpty().WithErrorCode(ErrorCodes.IsRequired)
                .MinimumLength(3).WithErrorCode(ErrorCodes.MinimumLength3)
                .MaximumLength(50).WithErrorCode(ErrorCodes.MaximumLength20)
                .Matches(@"^[a-zA-Z0-9\s]+$").WithErrorCode(ErrorCodes.LetterNumberSpaceOnly)
                .Configure(options => options.PropertyName = propertyName);
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
                .NotEmpty().WithErrorCode(ErrorCodes.IsRequired)
                .Matches(@"^(?!.*\.\.)(?!\.)(?!.*\.$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$").WithErrorCode(ErrorCodes.InvalidFormat)
                .Configure(options => options.PropertyName = "Email");
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
                .NotEmpty().WithErrorCode(ErrorCodes.IsRequired)
                .Matches(@"^(?:\+20|0)?1[0125]\d{8}$").WithErrorCode(ErrorCodes.InvalidFormat)
                .Configure(options => options.PropertyName = "Egyptian phone number");
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
                .NotEmpty().WithErrorCode(ErrorCodes.IsRequired)

                .MinimumLength(8).WithErrorCode(ErrorCodes.MinimumLength8)

                .Matches(@"^\S+$").WithErrorCode(ErrorCodes.PasswordMustNotContainWhitespace)
                .Matches(@"[A-Z]").WithErrorCode(ErrorCodes.PasswordMustContainUppercase)
                .Matches(@"[a-z]").WithErrorCode(ErrorCodes.PasswordMustContainLowercase)
                .Matches(@"\d").WithErrorCode(ErrorCodes.PasswordMustContainDigit)
                .Matches(@"[@$!%*?&]").WithErrorCode(ErrorCodes.PasswordMustContainSpecialCharacter)
                .Configure(options => options.PropertyName = "Password");


        }
    }
}
