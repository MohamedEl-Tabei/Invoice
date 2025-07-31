using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models
{
    public class Price
    {
        public DateTime CreatedOn { get; set; }
        public string ItemId { get; set; }
        public decimal Value { get; set; }
        public Item Item { get; set; }
    }
}
