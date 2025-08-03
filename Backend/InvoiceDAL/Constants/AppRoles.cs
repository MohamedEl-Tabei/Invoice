using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    public static class AppRoles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Shop = "Shop";
        public const string Restaurant = "Restaurant";
        public const string StringRoles = $"{Admin}, {Customer}, {Shop}, {Restaurant}";
        public static List<string> Roles = new List<string>()
        {
            Admin.ToUpper(),
            Customer.ToUpper(),
            Shop.ToUpper(),
            Restaurant.ToUpper(),
        };
    }
}
