using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    public static class AppRoles
    {
        public static string Admin { get; } = "Admin";
        public static string User { get; } = "User";
        public static string Shop { get; } = "Shop";
        public static List<string> Roles { get; }= new List<string>()
        {
            Admin.ToUpper(),
            User.ToUpper(),
            Shop.ToUpper(),
        };
    }
}
