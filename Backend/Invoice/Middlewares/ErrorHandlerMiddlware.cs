
using InvoiceBL;

namespace Invoice.Middlewares
{
    public class ErrorHandlerMiddlware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var result = new Result<string>();
                result.Errors.Add(
                    new Error
                    {
                        Code = ex.Message,
                        Message = ex.Message,
                        PropertyName = ex.Data.GetType().Name
                    });
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(result);
                return;
            }
        }
    }
}
