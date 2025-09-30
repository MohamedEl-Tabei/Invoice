using FluentValidation;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Validation;
using InvoiceDAL;
using InvoiceDAL.Constants;
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
        private readonly IValidator<CategoryDTOUpdate> _validatorCategoryDTOUpdate;

        public CategoryManager(IUnitOfWork unitOfWork, IValidator<CategoryDTOCreate> validatorCategoryDTOCreate,IValidator<CategoryDTOUpdate> validatorCategoryDTOUpdate)
        {
            _unitOfWork = unitOfWork;
            _validatorCategoryDTOCreate = validatorCategoryDTOCreate;
            _validatorCategoryDTOUpdate = validatorCategoryDTOUpdate;

        }
        #region Create
        public async Task<Result<string>> CreateAsync(CategoryDTOCreate categoryDTOCreate)
        {
            var result = new Result<string>();
            categoryDTOCreate.Name = categoryDTOCreate.Name.Trim().ToLower();
            #region Check category is valid
            var validatorResult = _validatorCategoryDTOCreate.Validate(categoryDTOCreate);
            if (!validatorResult.IsValid)
            {
                result.Errors.AddRange(validatorResult.ToErrorList());
                return result;
            }
            #endregion
            #region Check Name of Category is unique
            var isUsed = await _unitOfWork._CategoryRepo.IsUsedAsync(c => c.Name == categoryDTOCreate.Name);
            if (isUsed)
            {
                result.Errors.Add(new Error { Code = ErrorCodes.Conflict, Message = $"{categoryDTOCreate.Name} is exist.", PropertyName = "Name" });
                return result;
            }
            #endregion
            await _unitOfWork.startTransactionAsync();
            var newCategory = new Category() { Name = categoryDTOCreate.Name };
            await _unitOfWork._CategoryRepo.CreateAsync(newCategory);
            //await _unitOfWork.SaveChangesAsync(); Changes will be saved by middleware AdminLoggingMiddleware
            result.Data = $"'{categoryDTOCreate.Name}' created successfully";
            result.Successed = true;
            return result;
        }
        #endregion
        #region Get All
        public async Task<Result<List<CategoryDTOGetForAdmin>>> GetAllForAdminAsync()
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
                }).OrderBy(c => c.Name).ToList();
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
        #region Get by Id
        public async Task<Result<CategoryDTOGetForAdmin>> GetForAdminAsyncById(string id)
        {
            var result = new Result<CategoryDTOGetForAdmin>();
            var category =await _unitOfWork._CategoryRepo.GetByIdAsync(id);
            #region Check category is exist
            if (category == null)
            {
                result.Errors.Add(new Error { Code = ErrorCodes.NotFound, Message = $"This category is not found.", PropertyName = "Id" });
                return result;
            }
            #endregion
            result.Data=new CategoryDTOGetForAdmin()
            {
                Id = category.Id,
                ConcurrencyStamp = category.ConcurrencyStamp,
                Name = category.Name
            };
            result.Successed = true;
            return result;
        }
        #endregion
        #region Update
        public async Task<Result<string>> UpdateAsync(CategoryDTOUpdate categoryDTOUpdate)
        {
            var result = new Result<string>();
            var category = await _unitOfWork._CategoryRepo.GetByIdAsync(categoryDTOUpdate.Id);

            #region Check category is exist
            if (category == null)
            {
                result.Errors.Add(new Error { Code = ErrorCodes.NotFound, Message = $"This category is not found.", PropertyName = "Id" });
                return result;
            }
            #endregion
            #region 400 Check name is new && Check name is valid
            if (category.Name.ToLower() == categoryDTOUpdate.NewName.ToLower().Trim())
                result.Errors.Add(new Error { Code = ErrorCodes.BadRequest, Message = $"The name is not changed.", PropertyName = "Name" });
            var validatorResult = _validatorCategoryDTOUpdate.Validate(categoryDTOUpdate);
            if (!validatorResult.IsValid)
                result.Errors.AddRange(validatorResult.ToErrorList());
            if (result.Errors.Any()) return result;
            #endregion
            #region 409 Check concurrency stamp is correct && Check Name of Category is unique
            if (category.ConcurrencyStamp != categoryDTOUpdate.ConcurrencyStamp)
                result.Errors.Add(new Error { Code = ErrorCodes.Conflict, Message = $"This category is changed, please enter the new ConcurrencyStamp({category.ConcurrencyStamp}).", PropertyName = "ConcurrencyStamp" });
            var isUsed = await _unitOfWork._CategoryRepo.IsUsedAsync(c => c.Name.ToLower() == categoryDTOUpdate.NewName.Trim().ToLower());
            if (isUsed)
                result.Errors.Add(new Error { Code = ErrorCodes.Conflict, Message = $"{categoryDTOUpdate.NewName} is exist.", PropertyName = "Name" });
            if (result.Errors.Any()) return result;

            #endregion
            await _unitOfWork.startTransactionAsync();
            category.Name = categoryDTOUpdate.NewName.ToLower().Trim();
            category.ConcurrencyStamp = Guid.NewGuid().ToString();
            result.Successed = true;
            result.Data = category.ConcurrencyStamp;
            //await _unitOfWork.SaveChangesAsync(); Changes will be saved by middleware AdminLoggingMiddleware
            return result;
        }
        #endregion
    }
}
