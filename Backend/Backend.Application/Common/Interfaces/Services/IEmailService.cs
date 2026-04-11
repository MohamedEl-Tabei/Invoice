using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendConfirmationAsync(string email,string userId,string token);

    }
}
