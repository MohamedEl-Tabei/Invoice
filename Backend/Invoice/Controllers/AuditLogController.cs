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
        #region Get Page of Audit Logs
        [Authorize(Policy = AppRoles.Admin)]
        [HttpGet("page")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result<List<AuditLogDTOGet>>), StatusCodes.Status200OK)]
        [EndpointSummary("Get by Page Number (Admin only)​")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It retrieves a specific page of audit logs.")]
        public async Task<ActionResult> GetHistoryPageAsync([FromQuery] int pageNumber)
        {
            var result = await _auditLogManager.GetPageAsync(pageNumber);
            if (result.Successed)
                return Ok(result);
            else
                return NoContent();

        }
        #endregion
    }
}
