using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class AuditLogDTOGet
    {
        public string Action { get; set; } 
        public string Entity { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string AdminUserName { get; set; }
    }
}
