using InvoiceDAL.Context;
using InvoiceDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public TestController(InvoiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var Transportation = _context.Categories.Include(c=>c.Items).FirstOrDefault(c => c.Name == "Transportation");
            var itemsDes = Transportation.Items.Select(i=>i.Description);
            throw new Exception("NOooooooooooo");
            return itemsDes.ToList();

        }
    }
}
