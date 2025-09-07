using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using InvoiceDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class AuditLogRepo : IAuditLogRepo
    {
        private readonly InvoiceContext _context;

        public AuditLogRepo(InvoiceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AuditLog auditLog)
        {
            await _context.AuditLogs.AddAsync(auditLog);
        }

        public async Task<List<AuditLog>> GetPageAsyncWithAdmin(int pageNumber)
        {
            var history = await _context.AuditLogs.Skip((pageNumber - 1) * 10).Take(10).Include(x => x.Admin).ToListAsync();

            return history;
        }
    }
}
