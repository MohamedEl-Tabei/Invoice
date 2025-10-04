using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    public static class Messages
    {
        public static string GetDeleteMessage(string name) => $"Deleted! The {name.ToLower()} was removed successfully.";
        public static string GetCreateMessage(string name) => $"{name} was created successfully.";
        public static string GetIsExistMessage(string name) => $"The {name} already exists. Please choose a different one.";
        public static string GetNotFoundMessage(string entityName) => $"We couldn't find this {entityName}.";
        public static string GetNotFoundMessage(string entitiesName, string entityGetBy) => $"No {entitiesName} found for this {entityGetBy}.";
        public static string GetConflictMessage(string entityName, string concurrencyStamp) => $"This {entityName} is changed, please enter the new ConcurrencyStamp({concurrencyStamp}).";
        public static string GetNotChangedMessage(string name) => $"{name} has not been modified.";
    }
}
