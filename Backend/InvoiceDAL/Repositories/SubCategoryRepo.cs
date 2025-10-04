using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using InvoiceDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class SubCategoryRepo : Repository<SubCategory>, ISubCategoryRepo
    {
        private readonly InvoiceContext _context;
        public SubCategoryRepo(InvoiceContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(string categoryId)
        {
            var result = await _context.SubCategories.Where(sc => sc.CategoryId == categoryId).ToListAsync();
            return result;
        }
    }
}
