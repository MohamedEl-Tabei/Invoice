using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class CategoryDTOGet
    {
        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
    }
}
