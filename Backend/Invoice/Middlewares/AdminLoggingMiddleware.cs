
using InvoiceBL.IManagers;
using InvoiceDAL.Constants;

namespace Invoice.Middlewares
{
    public class AdminLoggingMiddleware : IMiddleware
    {
        private readonly IAuditLogManager _auditLogManager;

        public AdminLoggingMiddleware(IAuditLogManager auditLogManager)
        {
            _auditLogManager = auditLogManager;

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var isAdmin = context.User.IsInRole(AppRoles.Admin);
            if (isAdmin)
            {
                await _auditLogManager.LogAdminActionAsync(context);
            }
            await next(context);
        }
    }
}
