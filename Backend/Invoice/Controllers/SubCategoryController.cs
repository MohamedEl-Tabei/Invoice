using InvoiceBL;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceBL.Managers;
using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryManager _subCategoryManager;

        public SubCategoryController(ISubCategoryManager subCategoryManager)
        {
            _subCategoryManager = subCategoryManager;
        }
        #region Get All By Category Id
        [HttpGet("getByCategoryId/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<List<SubCategoryDTOGet>>), StatusCodes.Status200OK)]
        [EndpointSummary("Get by category id")]
        [EndpointDescription("This endpoint retrieves all sub-categories that belong to a specific category by its ID.")]

        public async Task<ActionResult> GetByCategoryId(string categoryId)
        {
            var result = await _subCategoryManager.GetSubCategoriesByCategoryIdAsync(categoryId);
            return this.HandleResponse(result);
        }
        #endregion
    }
}
