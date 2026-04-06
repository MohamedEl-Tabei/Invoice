using Backend.Application.Common.Errors.Models;
using Backend.Application.Common.Result.Failure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Result.Factory
{
    public static class ResultFactory
    {
        public static Success<T> Success<T>(T? data)
        {
            return new Success<T> { IsSuccess = true, Data = data };
        }
        public static DuplecatedFailure DuplecatedFailure(List<Error> errors)
        {
            return new DuplecatedFailure { IsSuccess = false, Errors = errors };
        }
        public static DuplecatedFailure DuplecatedFailure(Error error)
        {
            var errors = new List<Error> { error };
            return new DuplecatedFailure { IsSuccess = false, Errors = errors };
        }
        public static ValidationFailure ValidationFailure(List<Error> errors)
        {
            return new ValidationFailure { IsSuccess = false, Errors = errors };
        }

    }
}
