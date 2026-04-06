using Backend.Application.Common.Errors.Factory;
using Backend.Application.Common.Result.Factory;

namespace Backend.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex) {
                
            }
        }
    }
}
