using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    public class CRUD
    {
        private const string Create = "Create";
        private const string Read = "Read";
        private const string Update = "Update";
        private const string Delete = "Delete";
        public static Dictionary<string, string> Operations { get; } = new Dictionary<string, string>
        {
            { HttpMethods.Post, Create },
            { HttpMethods.Get, Read },
            { HttpMethods.Patch, Update },
            { HttpMethods.Put, Update },
            { HttpMethods.Delete, Delete }
        };

    }
}
