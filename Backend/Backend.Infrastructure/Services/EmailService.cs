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
        public async Task SendConfirmationAsync(string email, string token)
        {
            var title = "Confirm Your Email";
            var message = $"Please confirm your email by clicking this link: <a href='{baseUrl}confirm-email?token={token}'>Confirm Email</a>";
            await Task.Factory.StartNew(() =>
            {
                // Simulate sending email
                Console.WriteLine($"Sending email to {email} with title: {title} and message: {message}");
                // Simulate delay
                Task.Delay(2000).Wait();
                Console.WriteLine($"Email sent to {email}");
            });

        }
    }
}
