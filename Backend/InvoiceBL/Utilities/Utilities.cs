using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL
{
    internal static class Utilities
    {
        public static Error GetUniqueStringDataError(string propertyName)
        {
            return new Error()
            {
                Code = ErrorCodes.Conflict,
                Message = $"This {propertyName} is already in use",
                PropertyName = propertyName
            };
        }
    }
}
