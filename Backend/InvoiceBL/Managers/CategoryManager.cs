using FluentValidation;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Validation;
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
        private readonly IValidator<CategoryDTOCreate> _validatorCategoryDTOCreate;

        public CategoryManager(IUnitOfWork unitOfWork, IValidator<CategoryDTOCreate> validatorCategoryDTOCreate)
        {
            _unitOfWork = unitOfWork;
            _validatorCategoryDTOCreate = validatorCategoryDTOCreate;

        }
        #region Create
        public async Task<Result<CategoryDTOGetForAdmin>> CreateAsync(CategoryDTOCreate categoryDTOCreate)
        {
            var result = new Result<CategoryDTOGetForAdmin>();
            #region Check category is valid
            var validatorResult = _validatorCategoryDTOCreate.Validate(categoryDTOCreate);
            if (!validatorResult.IsValid)
            {
                result.Errors.AddRange(validatorResult.ToErrorList());
                return result;
            }
            #endregion
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
            result.Data = new CategoryDTOGetForAdmin()
            {
                Name = categoryDTOCreate.Name,
                Id = newCategory.Id,
                ConcurrencyStamp = newCategory.ConcurrencyStamp,
            };
            result.Successed = true;
            return result;
        }
        #endregion
        #region Get All
        public async Task<Result<List<CategoryDTOGetForAdmin>>> GetAllAsync()
        {
            var result = new Result<List<CategoryDTOGetForAdmin>>();

            var categories = await _unitOfWork._CategoryRepo.GetAllAsync();
            #region check have categories
            if (categories != null && categories.Any())
            {
                result.Data = categories.Select(c => new CategoryDTOGetForAdmin()
                {
                    Id = c.Id,
                    ConcurrencyStamp = c.ConcurrencyStamp,
                    Name = c.Name
                }).ToList();
                result.Successed = true;
                return result;
            }
            #endregion
            #region don't have categories
            result.Errors.Add(new Error()
            {
                Code = "EmptyCategories",
                Message = "No categories found in the system.",
            });
            return result;
            #endregion
        }
        #endregion
    }
}
