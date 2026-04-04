using Backend.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Result
{
    public class Failure : BaseResult
    {
        public List<string>? Errors { get; set; }
        public ErrorsType ErrorsType { get; set; }
    }
}
