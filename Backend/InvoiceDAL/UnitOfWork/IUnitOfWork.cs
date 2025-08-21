using InvoiceDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL
{
    public interface IUnitOfWork
    {
        public IItemRepo _ItemRepo { get; }
        public IUserRepo _UserRepo { get; }
        public ICategoryRepo _CategoryRepo { get; }
        public Task SaveChangesAsync();
    }
}
