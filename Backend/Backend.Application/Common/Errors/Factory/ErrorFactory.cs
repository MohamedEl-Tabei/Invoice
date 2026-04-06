using Backend.Application.Common.Errors.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Errors.Factory
{
    public static class ErrorFactory
    {
        public static Error Create(string code,string PropertyName)
        {
            return new Error
            {
                PropertyName = PropertyName,
                Code = code
            };
        }
    }
}
