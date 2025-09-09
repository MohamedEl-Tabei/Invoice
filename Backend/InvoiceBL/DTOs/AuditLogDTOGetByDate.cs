using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class AuditLogDTOGetByDate
    {
        public TimeOnly Time { get; set; }

        public string Details { get; set; }
    }
}
