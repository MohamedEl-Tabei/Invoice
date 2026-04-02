using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Extensions
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string str)
        {
            var _str = str.Trim(); 
            var firstLetter = char.ToUpper(_str[0]);
            var restOfString = _str[1..];
            return $"{firstLetter}{restOfString}";

        }
    }
}
