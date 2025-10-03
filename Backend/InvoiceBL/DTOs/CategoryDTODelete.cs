using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class CategoryDTODelete
    {
        [Description("Id is required.")]
        public string Id { get; set; }
        [Description("ConcurrencyStamp is required.")]
        public string ConcurrencyStamp { get; set; }
    }
}
