using Backend.Application.Common.Result.Base;
using Backend.Application.Common.Result.Failure;

namespace Backend.Extension
{
    public static class ResulsExtensions
    {
        public static IResult ToHToHttpResult(this BaseResult result)
        {
            if (result.IsSuccess) return Results.Ok(result);
            else return HandleFailure(result);

        }
        private static IResult HandleFailure(BaseResult result)
        {
            switch (result)
            {
                case ValidationFailure: return Results.BadRequest(result);
                case DuplecatedFailure: return Results.Conflict(result);
                case NotFoundFailure: return Results.NotFound(result);
                default: return Results.InternalServerError(result);
            }

        }
    }
}
