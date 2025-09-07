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
        public Task<Result<string>> CreateAsync(CategoryDTOCreate categoryDTOCreate);
        public Task<Result<List<CategoryDTOGetForAdmin>>> GetAllForAdminAsync();
    }
}
