using InvoiceDAL.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTORegister
    {
        [Description("- Unique.\n - Required. \n - Must be between 3 and 20 characters. \n - Must start with a letter.")]
        public string UserName { get; set; }
        [Description("- Unique.\n - Required. \n - Must be a valid email address format like user@invoice.com.")]
        public string Email { get; set; }
        [Description("- Required. \n - Must be at least 8 characters long. \n - Must contain at least: `one uppercase letter.` `one lowercase letter.` `one number.` `one special character.`")]
        public string Password { get; set; }
        [Description("- Confirmation of the password.\n- Must match the password field exactly.")]
        public string ConfirmPassword { get; set; }
        
        [Description("- Unique.\n - Required.\n- Must be 11 digits.\n- Must start with 010, 011, 012, or 015 (Egyptian phone number format).")]
        public string PhoneNumber { get; set; }

    }

}
