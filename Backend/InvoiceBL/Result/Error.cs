using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string PropertyName { get; set; }
    }
}
