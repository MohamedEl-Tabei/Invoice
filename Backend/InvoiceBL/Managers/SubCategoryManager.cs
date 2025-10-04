using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL;
using InvoiceDAL.Constants;
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

        public SubCategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Result<List<SubCategoryDTOGet>>> GetSubCategoriesByCategoryIdAsync(string id)
        {
            var subCategories = await _unitOfWork._SubCategoryRepo.GetSubCategoriesByCategoryIdAsync(id);
            var result = new Result<List<SubCategoryDTOGet>>();
            #region check if subCategories is null or empty
            if (subCategories == null || !subCategories.Any())
            {
                result.Errors.Add(new Error { Code = ErrorCodes.NotFound, Message = Messages.GetNotFoundMessage(ModelName.SubCategories,ModelName.SubCategory) });
                return result;
            }
            #endregion
            result.Data= subCategories.Select(sc => new SubCategoryDTOGet
            {
                Id = sc.Id,
                Name = sc.Name,
            }).ToList();
            result.Successed = true;
            return result;
        }   
    }
}
