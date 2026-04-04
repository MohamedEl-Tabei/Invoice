using Backend.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public async Task SendConfirmationAsync(string phoneNumber, string token)
        {
            var title = "Confirm Your Phone Number";
            var message = $"Please confirm your phone number by using this token: {token}";
            await Task.Factory.StartNew(() =>
            {
                // Simulate sending SMS
                Console.WriteLine($"Sending SMS to {phoneNumber} with message: {message}");
                // Simulate delay
                Task.Delay(2000).Wait();
                Console.WriteLine($"SMS sent to {phoneNumber}");
            });
        }
    }
}
