using InvoiceBL;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        #region Create  For Admin
        [Authorize(Policy = AppRoles.Admin)]
        [HttpPost("create")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [EndpointSummary("Create (Admin only)")]
        [EndpointDescription("Allows only Admins to create a new category.")]

        public async Task<ActionResult> Create(CategoryDTOCreate categoryDTOCreate)
        {
            this.HttpContext.Items["NewData"] = categoryDTOCreate.Name;
            var result = await _categoryManager.CreateAsync(categoryDTOCreate);
            return this.HandleResponse(result);

        }
        #endregion
        #region Get All For Admin
        [Authorize(Policy = AppRoles.Admin)]
        [HttpGet("admin/getAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result<List<CategoryDTOGetForAdmin>>), StatusCodes.Status200OK)]
        [EndpointSummary("Get all (Admin only)")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It retrieves all categories including their concurrency stamps.")]
        public async Task<ActionResult> GetAllForAdmin()
        {
            var result = await _categoryManager.GetAllForAdminAsync();
            return this.HandleResponse(result);
        }

        #endregion
        #region Update For Admin
        [Authorize(Policy = AppRoles.Admin)]
        [HttpPut("admin/update")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status409Conflict)]
        [EndpointSummary("Update (Admin only)")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It updates an existing category.")]
        public async Task<ActionResult> Update(CategoryDTOUpdate categoryDTOUpdate)
        {
            this.HttpContext.Items["NewData"] = $"{categoryDTOUpdate.NewName} ({categoryDTOUpdate.Id})";
            var result = await _categoryManager.UpdateAsync(categoryDTOUpdate);
            return this.HandleResponse(result);
        }

        #endregion
    }
}
