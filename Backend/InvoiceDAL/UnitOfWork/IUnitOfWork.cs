using InvoiceDAL.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL
{
    public interface IUnitOfWork:IDisposable
    {
        public IItemRepo _ItemRepo { get; }
        public IUserRepo _UserRepo { get; }
        public ICategoryRepo _CategoryRepo { get; }
        public IAuditLogRepo _AuditLogRepo { get; }
        public ISubCategoryRepo _SubCategoryRepo { get; }
        public IDbContextTransaction _Transaction { get; set; }
        public Task startTransactionAsync();
        public Task SaveChangesAsync();
    }
}
