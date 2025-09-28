using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    public static class ErrorCodes
    {
        public const string NotFound = "ERR-404";
        public const string BadRequest = "ERR-400";
        public const string Conflict = "ERR-409";
    }
}
