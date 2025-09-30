using InvoiceBL.DTOs;
using InvoiceDAL.Models;
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
        public Task<Result<CategoryDTOGetForAdmin>> GetForAdminAsyncById(string id);
        public Task<Result<string>> UpdateAsync(CategoryDTOUpdate categoryDTOUpdate);
    }
}
