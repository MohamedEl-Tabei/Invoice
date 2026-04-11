using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Contracts
{
    public class ConfirmEmailRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
