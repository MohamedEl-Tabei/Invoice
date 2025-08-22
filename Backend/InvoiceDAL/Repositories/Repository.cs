using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> IsUniqueAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().AnyAsync<T>(predicate);
            return !result;
        }
    }
}
