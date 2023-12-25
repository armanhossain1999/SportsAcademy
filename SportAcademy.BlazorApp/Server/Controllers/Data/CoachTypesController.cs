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
    public class CoachTypesController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public CoachTypesController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/CoachTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachType>>> GetCoachTypes()
        {
            if (_context.CoachTypes == null)
            {
                return NotFound();
            }
            return await _context.CoachTypes.ToListAsync();
        }

        // GET: api/CoachTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachType>> GetCoachType(int id)
        {
            if (_context.CoachTypes == null)
            {
                return NotFound();
            }
            var coachType = await _context.CoachTypes.FindAsync(id);

            if (coachType == null)
            {
                return NotFound();
            }

            return coachType;
        }

        // PUT: api/CoachTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachType(int id, CoachType coachType)
        {
            if (id != coachType.CoachTypeId)
            {
                return BadRequest();
            }

            _context.Entry(coachType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachTypeExists(id))
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

        // POST: api/CoachTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachType>> PostCoachType(CoachType coachType)
        {
            if (_context.CoachTypes == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.CoachTypes'  is null.");
            }
            _context.CoachTypes.Add(coachType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachType", new { id = coachType.CoachTypeId }, coachType);
        }

        // DELETE: api/CoachTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachType(int id)
        {
            if (_context.CoachTypes == null)
            {
                return NotFound();
            }
            var coachType = await _context.CoachTypes.FindAsync(id);
            if (coachType == null)
            {
                return NotFound();
            }

            _context.CoachTypes.Remove(coachType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachTypeExists(int id)
        {
            return (_context.CoachTypes?.Any(e => e.CoachTypeId == id)).GetValueOrDefault();
        }
    }
}
