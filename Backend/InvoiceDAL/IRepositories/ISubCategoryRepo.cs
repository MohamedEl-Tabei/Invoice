using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.IRepositories
{
    public interface ISubCategoryRepo:IRepository<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(string categoryId);
    }
}
