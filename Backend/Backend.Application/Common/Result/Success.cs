using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Result
{
    public class Success<T> : BaseResult
    {
        public T? Data { get;  set; }

    }
}
