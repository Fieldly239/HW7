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

        [HttpGet("{id}")]
        public async Task<ActionResult<Appilcation>> GetSingleBack(int id)
        {
            var apps = await _context.Appilcations
                
                
                .FirstOrDefaultAsync(h => h.Id == id);
            if (apps == null)
            {
                return NotFound("Sorry, no appilcation here. :/");
            }
            return Ok(apps);
        }

        [HttpPost]
        public async Task<ActionResult<List<Appilcation>>> CreateAppilcation(Appilcation apps)
        {
            
            _context.Appilcations.Add(apps);
            await _context.SaveChangesAsync();
            return Ok(await GetDbApps());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Appilcation>>> UpdateAppilcation(Appilcation apps, int id)
        {
            var dbApps = await _context.Appilcations
                
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbApps == null)
                return NotFound("Sorry, but no feedback for you. :/");
            dbApps.Name = apps.Name;
            dbApps.Description = apps.Description;
            

            await _context.SaveChangesAsync();
            return Ok(await GetDbApps());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Appilcation>>> DeleteAppilcation(int id)
        {
            var dbApps = await _context.Appilcations
                
                .FirstOrDefaultAsync(a => a.Id == id);
            if (dbApps == null)
                return NotFound("Sorry, but no feedback for you. :/");

            _context.Appilcations.Remove(dbApps);
            await _context.SaveChangesAsync();
            return Ok(await GetDbApps());
        }

        private async Task<List<Appilcation>> GetDbApps()
        {
            return await _context.Appilcations.ToListAsync();
        }
    }
}
