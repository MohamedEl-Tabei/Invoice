using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTOLoginEmail:UserDTOLoginBase
    {
        [Description("- Required. \n - Must be a valid email address format like user@invoice.com.")]
        public string Email { get; set; }
       
    }
}
