using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.IManagers
{
    public interface ISubCategoryManager
    {
        Task<Result<List<SubCategoryDTOGet>>> GetSubCategoriesByCategoryIdAsync(string id);
    }
}
