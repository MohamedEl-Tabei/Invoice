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
        #region Get Page of Audit Logs
        public async Task<Result<List<AuditLogDTOGetByDate>>> GetByDateAsync(DateOnly date)
        {
            var history = await _unitOfWork._AuditLogRepo.GetByDateAsyncWithAdmin(date);
            var result = new Result<List<AuditLogDTOGetByDate>>();
            if (history != null && history.Count != 0)
            {
                result.Data = history.Select(x => new AuditLogDTOGetByDate
                {
                    Details = $"{x.Admin.UserName} {x.Action.ToLower()} {x.Entity.ToLower()} '{x.Data}'",
                    Date = x.Timestamp,
                }).ToList();
                result.Successed = true;
            }
            return result;
        }
        #endregion
        #region Log Actions of Admins used in middleware
        public async Task LogAdminActionAsync(HttpContext httpContext)
        {
            if (!httpContext.User.IsInRole(AppRoles.Admin))
                throw new UnauthorizedAccessException("Only admins can log admin actions.");
            if (httpContext.Request.Method == HttpMethods.Get)
                return;
            var adminIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var entity = httpContext.Request.Path.Value.Split('/')[2];
            if (adminIdClaim != null)
            {
                var action = CRUD.Operations.GetValueOrDefault(httpContext.Request.Method);
                var auditLog = new AuditLog
                {
                    AdminId = adminIdClaim.Value,
                    Action = action,
                    Entity = entity,
                    Data = httpContext.Items["NewData"]?.ToString()
                };
                await _unitOfWork._AuditLogRepo.AddAsync(auditLog);
                await _unitOfWork.SaveChangesAsync();
            }

        }
        #endregion
    }
}
