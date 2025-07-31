using InvoiceBL.IManagers;
using InvoiceBL.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL
{
    public static class ExtensionMethodBL
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAppManager,UserAppManager>();
        }
    }
}
