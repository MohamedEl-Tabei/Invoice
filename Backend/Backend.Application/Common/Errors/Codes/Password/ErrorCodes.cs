using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Errors.Codes
{
    public partial class ErrorCodes
    {
        public static readonly string PasswordMustContainUppercase = "PasswordMustContainUppercase";
        public static readonly string PasswordMustContainLowercase = "PasswordMustContainLowercase";
        public static readonly string PasswordMustContainDigit = "PasswordMustContainDigit";
        public static readonly string PasswordMustContainSpecialCharacter = "PasswordMustContainSpecialCharacter";
        public static readonly string PasswordMustNotContainWhitespace = "PasswordMustNotContainWhitespace";
    }
}
