using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.IManagers
{
    public interface ICategoryManager
    {
        public Task<Result<CategoryDTOGet>> CreateAsync(CategoryDTOCreate categoryDTOCreate);
    }
}
