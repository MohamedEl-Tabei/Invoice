using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL;
using InvoiceDAL.Constants;
using InvoiceDAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Managers
{
    public class AuditLogManager : IAuditLogManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditLogManager(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task LogAdminActionAsync(HttpContext httpContext)
        {
            if (!httpContext.User.IsInRole(AppRoles.Admin))
                throw new UnauthorizedAccessException("Only admins can log admin actions.");
            if (httpContext.Request.Method == HttpMethods.Get)
                return;
            var adminIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (adminIdClaim != null)
            {
                var auditLog = new AuditLog
                {
                    AdminId = adminIdClaim.Value,
                    Method = httpContext.Request.Method,
                    Endpoint = httpContext.Request.Path,
                };
                await _unitOfWork._AuditLogRepo.AddAsync(auditLog);
                await _unitOfWork.SaveChangesAsync();
            }

        }
    }
}
