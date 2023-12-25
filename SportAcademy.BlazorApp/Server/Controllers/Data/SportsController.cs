using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Shared.Models;

namespace SportAcademy.BlazorApp.Server.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public SportsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/Sports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSports()
        {
            if (_context.Sports == null)
            {
                return NotFound();
            }
            return await _context.Sports.ToListAsync();
        }
        // GET: api/Sports
        [HttpGet("Teams/Include")]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSportsWithTeams()
        {
            if (_context.Sports == null)
            {
                return NotFound();
            }
             var data =await _context.Sports.Include(x=>x.Teams).ToListAsync();
            return data;
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            if (_context.Sports == null)
            {
                return NotFound();
            }
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }
        // GET: api/Sports/5
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Sport>> GetSportWithTeam(int id)
        {
            if (_context.Sports == null)
            {
                return NotFound();
            }
            var sport = await _context.Sports.Include(x=>x.Teams).FirstOrDefaultAsync(x=>x.SportId == id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }
        // PUT: api/Sports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.SportId)
            {
                return BadRequest();
            }

            _context.Entry(sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            if (_context.Sports == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.Sports'  is null.");
            }
            _context.Sports.Add(sport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = sport.SportId }, sport);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(int id)
        {
            if (_context.Sports == null)
            {
                return NotFound();
            }
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportExists(int id)
        {
            return (_context.Sports?.Any(e => e.SportId == id)).GetValueOrDefault();
        }
    }
}
