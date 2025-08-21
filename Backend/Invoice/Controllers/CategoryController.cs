using InvoiceBL;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        #region Create
        [HttpPost("create")]
        [ProducesResponseType(typeof(Result<CategoryDTOGet>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>),StatusCodes.Status400BadRequest)]
        [EndpointDescription("Admin only create Category")]
        [EndpointSummary("Create")]
        public async Task<ActionResult> Create(CategoryDTOCreate categoryDTOCreate)
        {
            var result = await _categoryManager.CreateAsync(categoryDTOCreate);
            return result.Successed ? Ok(result) : BadRequest(result);

        }
        #endregion
    }
}
