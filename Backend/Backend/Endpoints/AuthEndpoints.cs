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
                await mediator.Send(command);
                return Results.Ok();
            }).WithTags("Authentication").WithName("Register");
            #endregion
        }
    }
}
