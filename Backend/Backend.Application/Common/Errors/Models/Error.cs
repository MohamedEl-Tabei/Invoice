using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Errors.Models
{
    public class Error
    {
        public string? Message { get; set; }
        public string Code { get; set; }
        public string PropertyName { get; set; }


    }
}
