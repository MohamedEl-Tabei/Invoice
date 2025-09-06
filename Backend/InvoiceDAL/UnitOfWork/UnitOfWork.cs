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
        public IItemRepo _ItemRepo { get; }
        public IUserRepo _UserRepo { get; }
        public ICategoryRepo _CategoryRepo { get; }

        public IAuditLogRepo _AuditLogRepo { get; }

        public UnitOfWork(InvoiceContext context, IItemRepo itemRepo, IUserRepo userRepo, ICategoryRepo categoryRepo, IAuditLogRepo auditLogRepo)
        {
            _context = context;
            _ItemRepo = itemRepo;
            _UserRepo = userRepo;
            _CategoryRepo = categoryRepo;
            _AuditLogRepo = auditLogRepo;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
