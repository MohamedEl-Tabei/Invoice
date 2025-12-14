using InvoiceBL;
using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Invoice
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// Handles a service result and returns the appropriate HTTP response
        /// based on the success state and error codes.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the data wrapped inside the <see cref="Result{T}"/>.
        /// </typeparam>
        /// <param name="controllerBase">
        /// The current controller instance used to generate HTTP responses.
        /// </param>
        /// <param name="result">
        /// The result object returned from the business layer.
        /// </param>
        /// <returns>
        /// An <see cref="ActionResult"/> with the corresponding HTTP status code.
        /// </returns>
        public static ActionResult HandleResponse<T>(this ControllerBase controllerBase, Result<T> result)
        {
            return result.Successed ? controllerBase.Ok(result)
               : result.Errors.Any(e => e.Code == ErrorCodes.NotFound) ? controllerBase.NotFound(result)
               : result.Errors.Any(e => e.Code == ErrorCodes.Conflict) ? controllerBase.Conflict(result)
               : result.Errors.Any(e => e.Code == ErrorCodes.BadRequest) ? controllerBase.BadRequest(result)
               : controllerBase.NoContent();
        }
    }
}
