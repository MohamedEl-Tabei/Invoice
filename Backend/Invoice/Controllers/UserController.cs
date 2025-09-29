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
            return this.HandleResponse(result);
        }
        #endregion

        #region Login By Email
        [HttpPost("login/email")]
        [ProducesResponseType(typeof(Result<UserDTOAuthenticated>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [EndpointDescription("This endpoint allows users to log in using their email and password.\r\n")]
        [EndpointSummary("Login By Email")]
        public async Task<ActionResult> LoginWithEmail([FromBody] UserDTOLoginEmail userDTOLoginEmail)
        {
            var result = await _userManager.LoginWithEmailAsync(userDTOLoginEmail);
            return this.HandleResponse(result);
        }
        #endregion 
        #region Login By UserName
        [HttpPost("login/username")]
        [ProducesResponseType(typeof(Result<UserDTOAuthenticated>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [EndpointDescription("This endpoint allows users to log in using their username and password.\r\n")]
        [EndpointSummary("Login By UserName")]
        public async Task<ActionResult> LoginWithUserName([FromBody] UserDTOLoginUserName userDTOLoginUserName)
        {
            var result = await _userManager.LoginWithUserNameAsync(userDTOLoginUserName);
            return this.HandleResponse(result);
        }
        #endregion
        #region Login By Phone Number
        [HttpPost("login/phone")]
        [ProducesResponseType(typeof(Result<UserDTOAuthenticated>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        [EndpointDescription("This endpoint allows users to log in using their phone number and password.\r\n")]
        [EndpointSummary("Login By Phone Number")]
        public async Task<ActionResult> LoginWithPhoneNumber([FromBody] UserDTOLoginPhoneNumber userDTOLoginPhoneNumber)
        {
            var result = await _userManager.LoginWithPhoneNumberAsync(userDTOLoginPhoneNumber);
            return this.HandleResponse(result);
        }
        #endregion


    }
}
