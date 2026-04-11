using Backend.Application.Common.Interfaces.Services;
using Backend.Application.Common.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly object baseUrl;

        public EmailService(IOptions<AppSettings> options)
        {
            baseUrl = options.Value.BaseURL;
        }
        public async Task SendConfirmationAsync(string email, string userId, string token)
        {
            var title = "Confirm Your Email";
            var message = $"Please confirm your email by clicking this link: <a href='{baseUrl}auth/confirm-email?userId={userId}&token={token}'>Confirm Email</a>";


        }
    }
}
