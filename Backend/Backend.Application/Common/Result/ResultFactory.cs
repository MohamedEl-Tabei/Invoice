using Backend.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Result
{
    public static class ResultFactory
    {
        public static Success<T> Success<T>(T? data)
        {
            return new Success<T> { IsSuccess = true, Data = data };
        }
        public static Failure Failure(ErrorsType errorsType, List<string> errors)
        {
            return new Failure { IsSuccess = false, ErrorsType = errorsType, Errors = errors };
        }
    }
}
