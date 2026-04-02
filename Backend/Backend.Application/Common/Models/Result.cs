using Backend.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Models
{
    public class Result<T>
    {
        public T? Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string>? Errors { get; private set; }
        public ErrorsType ErrorsType { get; private set; }

        private Result(T data, ErrorsType errorsType, List<string>? errors)
        {
            Data = data;
            Errors = errors;
            IsSuccess = errors is null || errors.Count == 0;
            ErrorsType = errorsType;
        }
        public static Result<T> Success<T>(T data)
        {
            return new Result<T>(data, ErrorsType.None, null);
        }
        public static Result<T> Failure(ErrorsType errorsType, List<string> errors)
        {
            return new Result<T>(default, errorsType, errors);
        }
    }
}
