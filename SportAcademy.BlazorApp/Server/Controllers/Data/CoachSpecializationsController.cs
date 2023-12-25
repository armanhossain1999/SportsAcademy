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
    public class CoachSpecializationsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public CoachSpecializationsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/CoachSpecializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachSpecialization>>> GetCoachSpecializations()
        {
          if (_context.CoachSpecializations == null)
          {
              return NotFound();
          }
            return await _context.CoachSpecializations.ToListAsync();
        }

        // GET: api/CoachSpecializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachSpecialization>> GetCoachSpecialization(int id)
        {
          if (_context.CoachSpecializations == null)
          {
              return NotFound();
          }
            var coachSpecialization = await _context.CoachSpecializations.FindAsync(id);

            if (coachSpecialization == null)
            {
                return NotFound();
            }

            return coachSpecialization;
        }

        // PUT: api/CoachSpecializations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachSpecialization(int id, CoachSpecialization coachSpecialization)
        {
            if (id != coachSpecialization.CoachSpecializationId)
            {
                return BadRequest();
            }

            _context.Entry(coachSpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachSpecializationExists(id))
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

        // POST: api/CoachSpecializations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachSpecialization>> PostCoachSpecialization(CoachSpecialization coachSpecialization)
        {
          if (_context.CoachSpecializations == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.CoachSpecializations'  is null.");
          }
            _context.CoachSpecializations.Add(coachSpecialization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachSpecialization", new { id = coachSpecialization.CoachSpecializationId }, coachSpecialization);
        }

        // DELETE: api/CoachSpecializations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachSpecialization(int id)
        {
            if (_context.CoachSpecializations == null)
            {
                return NotFound();
            }
            var coachSpecialization = await _context.CoachSpecializations.FindAsync(id);
            if (coachSpecialization == null)
            {
                return NotFound();
            }

            _context.CoachSpecializations.Remove(coachSpecialization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachSpecializationExists(int id)
        {
            return (_context.CoachSpecializations?.Any(e => e.CoachSpecializationId == id)).GetValueOrDefault();
        }
    }
}
