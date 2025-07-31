using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
