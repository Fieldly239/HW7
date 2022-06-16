using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrudCustom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppilcationsController : ControllerBase
    {
        private readonly DataContext _context;
        public AppilcationsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Appilcation>>> GetAppilcations()
        {
            var apps = await _context.Appilcations.ToListAsync();
            return Ok(apps);
        }
    }
}
