using InvoiceBL;
using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppManager _userManager;

        public UserController(IUserAppManager userManager)
        {
            _userManager = userManager;

        }
        #region Register
        [HttpPost("register")]
        [ProducesResponseType(typeof(Result<UserDTOAuthenticated>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [EndpointDescription("This endpoint allows new users to register by providing a username, email, password, phone number, and role.\r\n")]
        [EndpointSummary("Register")]
        public async Task<ActionResult> Register([FromBody] UserDTORegister userDTORegister)
        {
            var result = await _userManager.RegisterAsync(userDTORegister);
            return result.Successed ? Ok(result) : BadRequest(result);
        }
        #endregion
    }
}
