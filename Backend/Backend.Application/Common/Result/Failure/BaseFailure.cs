using Backend.Application.Common.Errors.Models;
using Backend.Application.Common.Result.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Result.Failure
{
    public class BaseFailure : BaseResult
    {
        public List<Error>? Errors { get; set; }
    }
}
