using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTORegister userDTORegister)
        {
            var result = await _userManager.RegisterAsync(userDTORegister);
            return result.Successed ? Ok(result) : BadRequest(result);
        }
    }
}
