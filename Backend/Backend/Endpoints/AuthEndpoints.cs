using Backend.Application.Features.Authentication.Register;
using MediatR;

namespace Backend.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            #region register
            app.MapPost("/api/auth/register", async (RegisterCommand command, IMediator mediator) =>
            {
                var result= await mediator.Send(command);
                if (!result.IsSuccess)
                {
                    return Results.BadRequest(result);
                }
                return Results.Ok(result);
            }).WithTags("Authentication").WithName("Register");
            #endregion
        }
    }
}
