using FluentValidation;
using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Validation
{
    public class ValidatorCategoryDTOCreate : AbstractValidator<CategoryDTOCreate>
    {
        public ValidatorCategoryDTOCreate()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).Matches("^[a-z A-Z]+$").WithMessage("Name can only include letters and spaces.");
        }
    }
}
