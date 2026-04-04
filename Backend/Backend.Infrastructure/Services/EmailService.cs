using Backend.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Services
{
    public class EmailService(IHttpContextAccessor httpContextAccessor) : IEmailService
    {

        public async Task SendConfirmationAsync(string email, string token)
        {
            var request = httpContextAccessor.HttpContext?.Request;
            if (request != null)
            {
                var baseUrl = $"{request.Scheme}://{request.Host}";
                var title = "Confirm Your Email";
                var message = $"Please confirm your email by clicking this link: <a href='{baseUrl}/confirm-email?token={token}'>Confirm Email</a>";
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
}
