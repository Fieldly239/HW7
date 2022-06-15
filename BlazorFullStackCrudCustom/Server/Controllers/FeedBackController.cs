using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrudCustom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedBackController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FeedBack>>> GetFeedBackes()
        {
            var backes = await _context.FeedBackes.Include(sh => sh.Vote).ToListAsync();
            return Ok(backes);
        }

        [HttpGet("votes")]
        public async Task<ActionResult<List<Vote>>> GetVotes()
        {
            var votes = await _context.Votes.ToListAsync();
            return Ok(votes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetSingleBack(int id)
        {
            var back = await _context.FeedBackes
                .Include(h => h.Vote)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (back == null)
            {
                return NotFound("Sorry, no feedback here. :/");
            }
            return Ok(back);
        }

        [HttpPost]
        public async Task<ActionResult<List<FeedBack>>> CreateFeedBack(FeedBack back)
        {
            back.Vote = null;
            _context.FeedBackes.Add(back);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBackes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<FeedBack>>> UpdateFeedBack(FeedBack back, int id)
        {
            var dbBack = await _context.FeedBackes
                .Include(sh => sh.Vote)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbBack == null)
                return NotFound("Sorry, but no feedback for you. :/");
            dbBack.AppilcationName = back.AppilcationName;
            dbBack.Description = back.Description;
            dbBack.VoteId = back.VoteId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbBackes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FeedBack>>> DeleteFeedBack(int id)
        {
            var dbBack = await _context.FeedBackes
                .Include(sh => sh.Vote)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbBack == null)
                return NotFound("Sorry, but no feedback for you. :/");

            _context.FeedBackes.Remove(dbBack);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBackes());
        }

        private async Task<List<FeedBack>> GetDbBackes()
        {
            return await _context.FeedBackes.Include(sh => sh.Vote).ToListAsync();
        }
    }
}
