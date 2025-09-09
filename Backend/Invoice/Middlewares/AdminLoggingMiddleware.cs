
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
            await next(context);
            var isSucess = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300;
            var isAdmin = context.User.IsInRole(AppRoles.Admin);
            if (isAdmin && isSucess)
            {
                await _auditLogManager.LogAdminActionAsync(context);
            }
        }
    }
}
