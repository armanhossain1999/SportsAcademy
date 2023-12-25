using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Shared.Models;

namespace SportAcademy.BlazorApp.Server.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachTeamsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public CoachTeamsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/CoachTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachTeam>>> GetCoachTeams()
        {
            if (_context.CoachTeams == null)
            {
                return NotFound();
            }
            return await _context.CoachTeams.ToListAsync();
        }

        // GET: api/CoachTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachTeam>> GetCoachTeam(int id)
        {
            if (_context.CoachTeams == null)
            {
                return NotFound();
            }
            var coachTeam = await _context.CoachTeams.FindAsync(id);

            if (coachTeam == null)
            {
                return NotFound();
            }

            return coachTeam;
        }

        // PUT: api/CoachTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachTeam(int id, CoachTeam coachTeam)
        {
            if (id != coachTeam.CoachId)
            {
                return BadRequest();
            }

            _context.Entry(coachTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachTeamExists(id))
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

        // POST: api/CoachTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachTeam>> PostCoachTeam(CoachTeam coachTeam)
        {
            if (_context.CoachTeams == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.CoachTeams'  is null.");
            }
            _context.CoachTeams.Add(coachTeam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoachTeamExists(coachTeam.CoachId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoachTeam", new { id = coachTeam.CoachId }, coachTeam);
        }

        // DELETE: api/CoachTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachTeam(int id)
        {
            if (_context.CoachTeams == null)
            {
                return NotFound();
            }
            var coachTeam = await _context.CoachTeams.FindAsync(id);
            if (coachTeam == null)
            {
                return NotFound();
            }

            _context.CoachTeams.Remove(coachTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachTeamExists(int id)
        {
            return (_context.CoachTeams?.Any(e => e.CoachId == id)).GetValueOrDefault();
        }
    }
}
