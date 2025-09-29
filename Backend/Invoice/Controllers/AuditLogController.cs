using InvoiceBL;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Managers;
using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogManager _auditLogManager;

        public AuditLogController(IAuditLogManager auditLogManager)
        {

            _auditLogManager = auditLogManager;
        }
        #region Get Audit Logs By Date
        [Authorize(Policy = AppRoles.Admin)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result<List<AuditLogDTOGetByDate>>), StatusCodes.Status200OK)]
        [EndpointSummary("Get by Date (Admin only)​")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It retrieves audit logs by date.")]
        public async Task<ActionResult> GetHistoryPageAsync([FromQuery] DateOnly date)
        {
            var result = await _auditLogManager.GetByDateAsync(date);
            return this.HandleResponse(result);
        }
        #endregion
    }
}
