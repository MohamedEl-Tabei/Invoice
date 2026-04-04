using Backend.Application.Common.Enums;
using Backend.Application.Common.Result;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Backend.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : BaseResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Any())
                {
                    var errors = failures.Select(f => f.ErrorMessage).ToList();
                    if (typeof(TResponse) == typeof(BaseResult))
                    {
                        return ResultFactory.Failure(ErrorsType.BadRequest, errors) as TResponse;
                    }
                    throw new Exception("Handler must return Result");

                }
            }
            return await next();
        }
    }
}
