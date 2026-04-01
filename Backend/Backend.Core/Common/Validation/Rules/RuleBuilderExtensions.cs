using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Validation.Rules
{
    public static class RuleBuilderExtensions
    {
        ///<summary>
        /// Validates that a string property is a valid name, which must be between 3 and 50 characters long and contain only letters.
        /// </summary>
        public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName = "Name")
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{propertyName} is required.")
                .MinimumLength(3).WithMessage($"{propertyName} must be at least 2 characters long.")
                .MaximumLength(50).WithMessage($"{propertyName} must not exceed 20 characters.")
                .Matches(@"^[a-zA-Z]+$").WithMessage($"{propertyName} must contain only letters");
        }
    }
}
