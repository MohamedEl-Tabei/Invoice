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
        private static string UserRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86";
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


    }
}
