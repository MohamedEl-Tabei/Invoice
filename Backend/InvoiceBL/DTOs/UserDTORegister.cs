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
        [Description("Required. Must be between 3 and 20 characters.")]
        public string UserName { get; set; }
        [Description("Required. Must be a valid email address format like user@invoice.com.")]
        public string Email { get; set; }
        [Description("Required. Must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }
        [Description("Confirmation of the password. Must match the password field exactly.")]
        public string ConfirmPassword { get; set; }
        [Description($"Required. Must be one of the following roles {AppRoles.StringRoles}")]
        public string Role { get; set; }
        [Description("Required. Must be 11 digits and start with 010, 011, 012, or 015 (Egyptian phone number format).")]
        public string PhoneNumber { get; set; }

    }

}
