using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a new string with the first character of the specified string capitalized.
        /// </summary>
        /// <remarks>The method trims any leading or trailing whitespace from the input string before
        /// capitalizing the first character.</remarks>
        /// <param name="str">The string to capitalize. Cannot be null or empty.</param>
        /// <returns>A string with the first character capitalized and all leading and trailing whitespace removed. If the input
        /// string is empty or consists only of whitespace, an empty string is returned.</returns>
        public static string CapitalizeFirstLetter(this string str)
        {
            var _str = str.Trim(); 
            var firstLetter = char.ToUpper(_str[0]);
            var restOfString = _str[1..];
            return $"{firstLetter}{restOfString}";

        }
    }
}
