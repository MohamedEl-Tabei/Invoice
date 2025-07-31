using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task CreateAsync(T entity);
    }
}
