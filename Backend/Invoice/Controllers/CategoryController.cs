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
            var result = await _categoryManager.CreateAsync(categoryDTOCreate);
            return result.Successed ? Ok(result) : BadRequest(result);

        }
        #endregion
        #region Get All For Admin
        [Authorize(Policy = AppRoles.Admin)]
        [HttpGet("admin/getAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result<List<CategoryDTOGetForAdmin>>),StatusCodes.Status200OK)]
        [EndpointSummary("Get all (Admin only)")]
        [EndpointDescription("This endpoint can only be accessed by Admins. It retrieves all categories including their concurrency stamps.")]
        public async Task<ActionResult> GetAllForAdmin()
        {
            var result = await _categoryManager.GetAllForAdminAsync();
            return result.Successed ? Ok(result) : NoContent();
        }

        #endregion
          
    }
}
