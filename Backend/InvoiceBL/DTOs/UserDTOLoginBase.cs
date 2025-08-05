using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTOLoginBase
    {
        [Description("- Required. \n - Must be at least 8 characters long. \n - Must contain at least: `one uppercase letter.` `one lowercase letter.` `one number.` `one special character.`")]
        public string Password { get; set; }
        [Description("- true: `Keeps you logged in for 7 days` \n - false: `Session expires in 2 hours`")]
        public bool RememberMe { get; set; }

    }
}
