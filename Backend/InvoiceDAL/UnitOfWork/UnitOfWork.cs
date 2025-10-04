using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        public ISubCategoryRepo _SubCategoryRepo { get; }
        public IDbContextTransaction _Transaction { get; set; }

        public UnitOfWork(InvoiceContext context, IItemRepo itemRepo, IUserRepo userRepo, ICategoryRepo categoryRepo, IAuditLogRepo auditLogRepo, ISubCategoryRepo subCategoryRepo)
        {
            _context = context;
            _ItemRepo = itemRepo;
            _UserRepo = userRepo;
            _CategoryRepo = categoryRepo;
            _AuditLogRepo = auditLogRepo;
            _SubCategoryRepo = subCategoryRepo;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_Transaction != null) await _Transaction.CommitAsync();
            }
            catch
            {

                if (_Transaction != null) await _Transaction.RollbackAsync();
                throw;
            }
        }

        public async Task startTransactionAsync()
        {
            _Transaction = await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _Transaction?.Dispose();
            _context.Dispose();
        }
    }
}
