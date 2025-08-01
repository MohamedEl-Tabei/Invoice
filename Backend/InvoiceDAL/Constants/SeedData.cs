using InvoiceDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    internal static class SeedData
    {
        private static string Password { get; } =
        "AQAAAAIAAYagAAAAEAI/ZvB0RzSNoEXTwA9r3oUiruneEEqYgP909s7aXBGUW/Sb7IcYItjn3NOjB8qJqA==";//Invoice123+
        #region Ids
        private static string AdminRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84";
        private static string ShopRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85";
        private static string UserRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86";
        private static string AdminAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe84";
        private static string ShopAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe85";
        private static string UserAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe86";
        #endregion
        public static HashSet<IdentityRole> Roles { get; } = new HashSet<IdentityRole>() {
           new()
           {
               Name=AppRoles.Admin,
               NormalizedName=AppRoles.Admin.ToUpper(),
               Id=AdminRole,
           },
           new()
           {
               Name=AppRoles.Shop,
               NormalizedName=AppRoles.Shop.ToUpper(),
               Id=ShopRole
           },
           new()
           {
               Name=AppRoles.User,
               NormalizedName=AppRoles.User.ToUpper(),
               Id = UserRole
           },
        };
        public static HashSet<UserApp> Users { get; } = new HashSet<UserApp>()
        {
            new()
            {
               Id=UserAppUser,
               SecurityStamp=UserAppUser,
               ConcurrencyStamp=UserAppUser,
               Email="user@invoice.com",
               PasswordHash=Password,
               UserName="user",
               PhoneNumber="01020210495"
            },new()
            {
               Id=ShopAppUser,
               SecurityStamp=ShopAppUser,
               ConcurrencyStamp=ShopAppUser,
               Email="shop@invoice.com",
               PasswordHash=Password,
               UserName="shop",
               PhoneNumber="01020210795"
            },new()
            {
               Id=AdminAppUser,
               SecurityStamp=AdminAppUser,
               ConcurrencyStamp=AdminAppUser,
               Email="admin@invoice.com",
               PasswordHash=Password,
               UserName="admin",
               PhoneNumber="01020210595"
            }
        };
        public static HashSet<IdentityUserRole<string>> UserRoles { get; } = new HashSet<IdentityUserRole<string>>(){
            new()
            {
                RoleId=AdminRole,
                UserId=AdminAppUser,
            },
            new()
            {
                RoleId=UserRole,
                UserId=UserAppUser,
            },
            new()
            {
                RoleId=ShopRole,
                UserId=ShopAppUser,
            },

        };

    }
}
