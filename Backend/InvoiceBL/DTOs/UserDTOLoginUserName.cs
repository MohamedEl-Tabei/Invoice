using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTOLoginUserName : UserDTOLoginBase
    {
        [Description("- Required. \n - Must be between 3 and 20 characters. \n - Must start with a letter.")]
        public string UserName { get; set; }
    }

}
