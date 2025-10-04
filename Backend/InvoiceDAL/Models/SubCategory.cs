using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models
{
    public class SubCategory
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string ConcurrencyStamp { get; set; }=Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public HashSet<Item> Items { get; set; } 
    }
}
