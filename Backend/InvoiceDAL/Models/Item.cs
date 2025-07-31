using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Unit {  get; set; }
        public decimal Quantity { get; set; }
        //Brand
        //Type
        public HashSet<Price> Prices { get; set; }

        
    }
}
