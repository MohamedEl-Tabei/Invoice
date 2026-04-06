using Backend.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Identity.Extensions
{
    public static class UserManagerExtensions
    {
        
        public async static Task<bool> IsPhoneNumberExistsAsync(this UserManager<User> userManager, string phoneNumber)
        {
            return await userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
