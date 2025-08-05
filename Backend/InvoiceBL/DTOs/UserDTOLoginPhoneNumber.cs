using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTOLoginPhoneNumber : UserDTOLoginBase
    {
        [Description("- Required.\n- Must be 11 digits.\n- Must start with 010, 011, 012, or 015 (Egyptian phone number format).")]
        public string PhoneNumber { get; set; }
    }
}
