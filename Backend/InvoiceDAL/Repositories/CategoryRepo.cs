using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using InvoiceDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(InvoiceContext invoiceContext) : base(invoiceContext){}

        
    }
}
