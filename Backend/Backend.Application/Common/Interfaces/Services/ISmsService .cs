using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Interfaces.Services
{
    public interface ISmsService
    {
        Task SendConfirmationAsync(string phoneNumber, string token);
    }
}
