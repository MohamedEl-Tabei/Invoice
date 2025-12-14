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
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<SubCategoryDTOCreate> _validatorSubCategoryDTOCreate;

        public SubCategoryManager(IUnitOfWork unitOfWork, IValidator<SubCategoryDTOCreate> validatorSubCategoryDTOCreate)
        {
            _unitOfWork = unitOfWork;
            _validatorSubCategoryDTOCreate = validatorSubCategoryDTOCreate;

        }
        #region get subcategories by category id
        public async Task<Result<List<SubCategoryDTOGet>>> GetSubCategoriesByCategoryIdAsync(string id)
        {
            var subCategories = await _unitOfWork._SubCategoryRepo.GetSubCategoriesByCategoryIdAsync(id);
            var result = new Result<List<SubCategoryDTOGet>>();
            #region check if subCategories is null or empty
            if (subCategories == null || !subCategories.Any())
            {
                result.Errors.Add(new Error { Code = ErrorCodes.NotFound, Message = Messages.GetNotFoundMessage(ModelName.SubCategories, ModelName.SubCategory) });
                return result;
            }
            #endregion
            result.Data = subCategories.Select(sc => new SubCategoryDTOGet
            {
                Id = sc.Id,
                Name = sc.Name,
                ConcurrencyStamp = sc.ConcurrencyStamp,
            }).ToList();
            result.Successed = true;
            return result;
        }
        #endregion
        #region create subcategory
        public async Task<Result<string>> CreateAsync(SubCategoryDTOCreate subCategoryDTOCreate)
        {
            var result = new Result<string>();
            
            #region Check Name of SubCategory is unique
            var isUsed = await _unitOfWork._SubCategoryRepo.IsUsedAsync(sc => sc.Name == subCategoryDTOCreate.Name);
            if (isUsed)
            {
                result.Errors.Add(new Error { Code = ErrorCodes.Conflict, Message = Messages.GetIsExistMessage(ModelName.SubCategory), PropertyName = "Name" });
                return result;
            }
            #endregion
            #region check if category exists
            var validCategory = await _unitOfWork._CategoryRepo.GetByIdAsync(subCategoryDTOCreate.CategoryId);
            if (validCategory == null)
            {
                result.Errors.Add(new Error { Code = ErrorCodes.NotFound, Message = Messages.GetNotFoundMessage(ModelName.Category), PropertyName = "CategoryId" });
                return result;
            }
            #endregion
            #region Check Name is valid
            var validatorResult = await _validatorSubCategoryDTOCreate.ValidateAsync(subCategoryDTOCreate);
            if(validatorResult.IsValid == false)
            {
                foreach(var error in validatorResult.Errors)
                {
                    result.Errors.Add(new Error { Code = ErrorCodes.BadRequest, Message = error.ErrorMessage, PropertyName = error.PropertyName });
                }
                return result;
            }
            #endregion
            #region Start Transaction
            await _unitOfWork.startTransactionAsync();
            #endregion
            #region Create new subcategory
            var subCategory = new SubCategory
            {
                Name = subCategoryDTOCreate.Name,
                CategoryId = subCategoryDTOCreate.CategoryId,
            };
            await _unitOfWork._SubCategoryRepo.CreateAsync(subCategory);
            #endregion
            result.Data = "success";
            result.Successed = true;
            return result;
        }
        #endregion
    }
}
