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
       
        #region Get All 
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result<List<CategoryDTOGet>>), StatusCodes.Status200OK)]
        [EndpointSummary("Get all")]
        [EndpointDescription("This endpoint retrieves all categories without their concurrency stamps.")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _categoryManager.GetAllAsync();
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
        #region Get one By Id
        [HttpGet("get")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status404NotFound)]
        [EndpointSummary("Get Category ")]
        [EndpointDescription("This endpoint retrieves the category by its ID.")]
        public async Task<ActionResult> Get([FromQuery] string id)
        {
            var result = await _categoryManager.GetByIdAsync(id);
            return this.HandleResponse(result);
        }

        #endregion
        #region Delete For Admin
        [Authorize(Policy = AppRoles.Admin)]
        [HttpDelete("admin/delete")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status409Conflict)]
        [EndpointSummary("Delete Category (Admin only)")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It Delete the category by its ID.")]
        public async Task<ActionResult> Delete([FromQuery]CategoryDTODelete categoryDTODelete)
        {
            this.HttpContext.Items["NewData"]=categoryDTODelete.Id;
            var result = await _categoryManager.DeleteAsync(categoryDTODelete);
            return this.HandleResponse(result);
        }

        #endregion
    }
}
