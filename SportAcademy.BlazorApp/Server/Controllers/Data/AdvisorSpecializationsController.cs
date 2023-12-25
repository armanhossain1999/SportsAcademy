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
    public class AdvisorSpecializationsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public AdvisorSpecializationsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/AdvisorSpecializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvisorSpecialization>>> GetAdvisorSpecializations()
        {
          if (_context.AdvisorSpecializations == null)
          {
              return NotFound();
          }
            return await _context.AdvisorSpecializations.ToListAsync();
        }

        // GET: api/AdvisorSpecializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvisorSpecialization>> GetAdvisorSpecialization(int id)
        {
          if (_context.AdvisorSpecializations == null)
          {
              return NotFound();
          }
            var advisorSpecialization = await _context.AdvisorSpecializations.FindAsync(id);

            if (advisorSpecialization == null)
            {
                return NotFound();
            }

            return advisorSpecialization;
        }

        // PUT: api/AdvisorSpecializations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvisorSpecialization(int id, AdvisorSpecialization advisorSpecialization)
        {
            if (id != advisorSpecialization.AdvisorSpecializationId)
            {
                return BadRequest();
            }

            _context.Entry(advisorSpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisorSpecializationExists(id))
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

        // POST: api/AdvisorSpecializations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvisorSpecialization>> PostAdvisorSpecialization(AdvisorSpecialization advisorSpecialization)
        {
          if (_context.AdvisorSpecializations == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.AdvisorSpecializations'  is null.");
          }
            _context.AdvisorSpecializations.Add(advisorSpecialization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvisorSpecialization", new { id = advisorSpecialization.AdvisorSpecializationId }, advisorSpecialization);
        }

        // DELETE: api/AdvisorSpecializations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisorSpecialization(int id)
        {
            if (_context.AdvisorSpecializations == null)
            {
                return NotFound();
            }
            var advisorSpecialization = await _context.AdvisorSpecializations.FindAsync(id);
            if (advisorSpecialization == null)
            {
                return NotFound();
            }

            _context.AdvisorSpecializations.Remove(advisorSpecialization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvisorSpecializationExists(int id)
        {
            return (_context.AdvisorSpecializations?.Any(e => e.AdvisorSpecializationId == id)).GetValueOrDefault();
        }
    }
}
