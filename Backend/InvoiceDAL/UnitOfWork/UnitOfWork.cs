using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvoiceContext _context;
        public readonly IItemRepo _ItemRepo;

        public UnitOfWork(InvoiceContext context,IItemRepo itemRepo)
        {

            _context=context;
            _ItemRepo = itemRepo;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
