using InvoiceBL;
using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Invoice
{
    public static class ExtensionMethod
    {
        public static ActionResult HandleResponse<T>(this ControllerBase controllerBase,Result<T> result)
        {
            return result.Successed ? controllerBase.Ok(result)
               : result.Errors.Any(e => e.Code == ErrorCodes.NotFound) ? controllerBase.NotFound(result)
               : result.Errors.Any(e => e.Code == ErrorCodes.Conflict) ? controllerBase.Conflict(result)
               : controllerBase.BadRequest(result);
        }
    }
}
