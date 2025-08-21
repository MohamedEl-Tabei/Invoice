using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL;
using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Result<CategoryDTOGet>> CreateAsync(CategoryDTOCreate categoryDTOCreate)
        {
            var result = new Result<CategoryDTOGet>();
            #region Check Name of Category is unique
            var isUniqueName = await _unitOfWork._CategoryRepo.IsUniqueAsync(c => c.Name == categoryDTOCreate.Name);
            if (!isUniqueName)
            {
                result.Errors.Add(new Error { Code = "NameIsNotUnique", Message = $"{categoryDTOCreate.Name} is exist.", PropertyName = "Name" });
                return result;
            }
            #endregion
            var newCategory = new Category() { Name = categoryDTOCreate.Name };
            await _unitOfWork._CategoryRepo.CreateAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();
            result.Data = new CategoryDTOGet()
            {
                Name = categoryDTOCreate.Name,
                Id = newCategory.Id,
                ConcurrencyStamp = newCategory.ConcurrencyStamp,
            };
            result.Successed = true;
            return result;
        }
    }
}
