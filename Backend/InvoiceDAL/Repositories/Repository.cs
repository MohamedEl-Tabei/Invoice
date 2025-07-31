using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InvoiceContext _context;

        public Repository(InvoiceContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
    }
}
