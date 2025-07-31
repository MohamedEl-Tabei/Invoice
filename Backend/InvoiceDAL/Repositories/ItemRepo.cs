using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class ItemRepo : Repository<Item>, IItemRepo
    {
        public ItemRepo(InvoiceContext context) : base(context) { }
    }
}
