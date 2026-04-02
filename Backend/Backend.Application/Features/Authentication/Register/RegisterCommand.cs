using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Features.Authentication.Register
{
    public sealed record RegisterCommand : RegisterDTO, IRequest;
       

}
