using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Enums
{
    public enum ErrorsType
    {
        None,
        NotFound,
        BadRequest,
        Unauthorized,
        Forbidden,
        Conflict,
        TooManyRequests,
        InternalServerError

    }
}
