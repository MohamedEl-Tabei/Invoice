using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class UserDTOAuthenticated
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
