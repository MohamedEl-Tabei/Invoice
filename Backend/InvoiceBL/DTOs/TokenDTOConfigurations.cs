using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class TokenDTOConfigurations
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public bool RememberMe { get; set; }
    }
}
