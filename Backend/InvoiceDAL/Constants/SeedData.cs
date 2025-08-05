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
        #region Ids
        private static string AdminRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84";
        private static string ShopRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85";
        private static string CustomerRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86";
        private static string RestaurantRole = "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86";
        private static string AdminAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe84";
        private static string ShopAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe85";
        private static string CustomerAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe86";
        private static string RestaurantAppUser = "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86";
        #endregion
        public static HashSet<IdentityRole> GetRoles()
        {
            return new HashSet<IdentityRole>(){

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
                    Name=AppRoles.Customer,
                    NormalizedName=AppRoles.Customer.ToUpper(),
                    Id = CustomerRole
                },
                new(){
                    Name=AppRoles.Restaurant,
                    NormalizedName=AppRoles.Restaurant.ToUpper(),
                    Id = RestaurantRole
                },
            };
        }
        public static HashSet<UserApp> GetUsers()
        {
            //Invoice123+
            return new HashSet<UserApp>()
            {
                new()
                {
                    Id = CustomerAppUser,
                    Email = "customer@invoice.com",
                    NormalizedEmail = "customer@invoice.com".ToUpper(),
                    UserName = "customer",
                    PhoneNumber = "01020210495",
                    PasswordHash="AQAAAAIAAYagAAAAEL7WjDMwY3woFxTEb0W7TPm2KCYv32cjIiqIycV9hbLbAQPGcBdVTUD6J0zqwNtEzQ==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = ShopAppUser,
                    Email = "shop@invoice.com",
                    NormalizedEmail = "shop@invoice.com".ToUpper(),
                    UserName = "shop",
                    PhoneNumber = "01020210795",
                    PasswordHash="AQAAAAIAAYagAAAAEIK9uTYXCvIWty97KaIFFZD3WEtTOnLwhEEd8Rmeh8pVc2CT6Nz4SaZ29Q/gcAPsmQ==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = AdminAppUser,
                    Email = "admin@invoice.com",
                    NormalizedEmail = "admin@invoice.com".ToUpper(),
                    UserName = "admin",
                    PhoneNumber = "01020210595",
                    PasswordHash= "AQAAAAIAAYagAAAAEKPr74T9wKgN2Rckq/lrBX/SBjQmOeXJxxeikNvCivCUe3THuR7c/fmcvzMMhkppuA==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = RestaurantAppUser,
                    Email = "restaurant@invoice.com",
                    NormalizedEmail = "restaurant@invoice.com".ToUpper(),
                    UserName = "restaurant",
                    PhoneNumber = "01020211595",
                    PasswordHash= "AQAAAAIAAYagAAAAEGdbCxXrHMnHDB8zj2UlxfY4/BPnIhBuTiykMG6xIwwGZXqwRZdtJBzu6bRIM98HQw==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                }

            };

        }
        public static HashSet<IdentityUserRole<string>> GetUserRoles()
        {
            return new HashSet<IdentityUserRole<string>>(){
                new(){
                    RoleId=AdminRole,
                    UserId=AdminAppUser,
                },
                new(){
                    RoleId=CustomerRole,
                    UserId=CustomerAppUser,
                },
                new(){
                    RoleId=ShopRole,
                    UserId=ShopAppUser,
                },
                new(){
                    RoleId=RestaurantRole,
                    UserId=RestaurantAppUser,
                },
            };
        }

    }
}
