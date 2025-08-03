using FluentValidation;
using FluentValidation.Results;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Managers;
using InvoiceBL.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace InvoiceBL
{
    public static class ExtensionMethodBL
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ValidatorUserDTORegister).Assembly);
            services.AddScoped<IUserAppManager, UserAppManager>();
            services.AddScoped<ITokenManger, TokenManager>();
        }
        public static List<Error> ToErrorList(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(x => new Error() { Message = x.ErrorMessage, Code = x.ErrorCode, PropertyName = x.PropertyName }).ToList();
        }
        public static List<Error> ToErrorList(this IdentityResult identityResult)
        {
            return identityResult.Errors.Select(x => new Error() { Message = x.Description, Code = x.Code, PropertyName = x.ToGetPropertyName() }).ToList();
        }
        public static string ToGetPropertyName(this IdentityError identityError)
        {
            return new List<string>()
            {
                "Passwodrd","Email","UserName","PhoneNumber"
            }.FirstOrDefault(x => identityError.Code.Contains(x));

        }
    }
}
