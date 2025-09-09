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

        public async Task<List<AuditLog>> GetByDateAsyncWithAdmin(DateOnly date)
        {
            var history = await _context.AuditLogs.Where(x => date == DateOnly.FromDateTime(x.Timestamp)).Include(x => x.Admin).ToListAsync();
            return history;
        }
    }
}
