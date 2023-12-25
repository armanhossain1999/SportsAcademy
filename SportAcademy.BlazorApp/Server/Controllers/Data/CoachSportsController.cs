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
    public class CoachSportsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public CoachSportsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/CoachSports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachSport>>> GetCoachSports()
        {
            if (_context.CoachSports == null)
            {
                return NotFound();
            }
            return await _context.CoachSports.ToListAsync();
        }

        // GET: api/CoachSports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachSport>> GetCoachSport(int id)
        {
            if (_context.CoachSports == null)
            {
                return NotFound();
            }
            var coachSport = await _context.CoachSports.FindAsync(id);

            if (coachSport == null)
            {
                return NotFound();
            }

            return coachSport;
        }

        // PUT: api/CoachSports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachSport(int id, CoachSport coachSport)
        {
            if (id != coachSport.CoachId)
            {
                return BadRequest();
            }

            _context.Entry(coachSport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachSportExists(id))
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

        // POST: api/CoachSports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachSport>> PostCoachSport(CoachSport coachSport)
        {
            if (_context.CoachSports == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.CoachSports'  is null.");
            }
            _context.CoachSports.Add(coachSport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoachSportExists(coachSport.CoachId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoachSport", new { id = coachSport.CoachId }, coachSport);
        }

        // DELETE: api/CoachSports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachSport(int id)
        {
            if (_context.CoachSports == null)
            {
                return NotFound();
            }
            var coachSport = await _context.CoachSports.FindAsync(id);
            if (coachSport == null)
            {
                return NotFound();
            }

            _context.CoachSports.Remove(coachSport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachSportExists(int id)
        {
            return (_context.CoachSports?.Any(e => e.CoachId == id)).GetValueOrDefault();
        }
    }
}
