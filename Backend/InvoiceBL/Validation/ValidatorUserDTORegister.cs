using FluentValidation;
using FluentValidation.Results;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorUserDTORegister : AbstractValidator<UserDTORegister>
    {
        public ValidatorUserDTORegister()
        {
            RuleFor(x => x.Email).NotEmpty();

        }
        
    }
}
