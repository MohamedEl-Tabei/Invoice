using FluentValidation;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorCategoryDTOUpdate : AbstractValidator<CategoryDTOUpdate>
    {
        public ValidatorCategoryDTOUpdate()
        {
            RuleFor(x => x.NewName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.NewName).Matches("^[a-z A-Z]+$").WithMessage("Name can only include letters and spaces.");
            RuleFor(x => x.ConcurrencyStamp).NotEmpty().WithMessage("ConcurrencyStamp is required.");
            
        }
    }
}
