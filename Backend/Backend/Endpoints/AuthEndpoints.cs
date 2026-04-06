using Backend.Application.Features.Authentication.Register;
using Backend.Extension;
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
                var result = await mediator.Send(command);
                return result.ToHToHttpResult();
            }).WithTags("Authentication").WithName("Register");
            #endregion
        }
    }
}
