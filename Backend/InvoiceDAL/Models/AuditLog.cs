using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models
{
    public class AuditLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AdminId { get; set; } 
        public string Method { get; set; } 
        public string Endpoint { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public UserApp Admin { get; set; }

    }
}
