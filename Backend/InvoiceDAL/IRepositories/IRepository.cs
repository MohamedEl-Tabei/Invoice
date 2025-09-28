using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task<bool> IsUsedAsync(Expression<Func<T, bool>> predicate);
        public Task<List<T>> GetAllAsync();
        public Task CreateAsync(T entity);
        public Task<T?> GetByIdAsync(string id);
    }
}
