using InvoiceBL.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.IManagers
{
    public interface IAuditLogManager
    {
        Task LogAdminActionAsync(HttpContext httpContext);
    }
}
