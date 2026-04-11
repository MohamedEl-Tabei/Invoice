using Backend.Application.Features.Authentication.ConfirmEmail;
using Backend.Application.Features.Authentication.Register;
using Backend.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            #region Confirm email
            app.MapGet("/api/auth/confirm-email", async (string userId, string token, IMediator mediator) =>
            {
                var command = new ConfirmEmailCommand() { Token = token, UserId = userId };
                var result = await mediator.Send(command);
                //return Results.Redirect("UI/URL")
                return result.ToHToHttpResult();
            }).WithTags("Authentication").WithName("Confirm Email");
            #endregion
        }
    }
}
