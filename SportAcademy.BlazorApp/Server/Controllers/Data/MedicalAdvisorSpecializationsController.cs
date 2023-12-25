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
    public class MedicalAdvisorSpecializationsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public MedicalAdvisorSpecializationsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalAdvisorSpecializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalAdvisorSpecialization>>> GetMedicalAdvisorSpecializations()
        {
            if (_context.MedicalAdvisorSpecializations == null)
            {
                return NotFound();
            }
            return await _context.MedicalAdvisorSpecializations.ToListAsync();
        }

        // GET: api/MedicalAdvisorSpecializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalAdvisorSpecialization>> GetMedicalAdvisorSpecialization(int id)
        {
            if (_context.MedicalAdvisorSpecializations == null)
            {
                return NotFound();
            }
            var medicalAdvisorSpecialization = await _context.MedicalAdvisorSpecializations.FindAsync(id);

            if (medicalAdvisorSpecialization == null)
            {
                return NotFound();
            }

            return medicalAdvisorSpecialization;
        }

        // PUT: api/MedicalAdvisorSpecializations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalAdvisorSpecialization(int id, MedicalAdvisorSpecialization medicalAdvisorSpecialization)
        {
            if (id != medicalAdvisorSpecialization.MedicalAdvisorId)
            {
                return BadRequest();
            }

            _context.Entry(medicalAdvisorSpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalAdvisorSpecializationExists(id))
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

        // POST: api/MedicalAdvisorSpecializations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalAdvisorSpecialization>> PostMedicalAdvisorSpecialization(MedicalAdvisorSpecialization medicalAdvisorSpecialization)
        {
            if (_context.MedicalAdvisorSpecializations == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.MedicalAdvisorSpecializations'  is null.");
            }
            _context.MedicalAdvisorSpecializations.Add(medicalAdvisorSpecialization);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicalAdvisorSpecializationExists(medicalAdvisorSpecialization.MedicalAdvisorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicalAdvisorSpecialization", new { id = medicalAdvisorSpecialization.MedicalAdvisorId }, medicalAdvisorSpecialization);
        }

        // DELETE: api/MedicalAdvisorSpecializations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalAdvisorSpecialization(int id)
        {
            if (_context.MedicalAdvisorSpecializations == null)
            {
                return NotFound();
            }
            var medicalAdvisorSpecialization = await _context.MedicalAdvisorSpecializations.FindAsync(id);
            if (medicalAdvisorSpecialization == null)
            {
                return NotFound();
            }

            _context.MedicalAdvisorSpecializations.Remove(medicalAdvisorSpecialization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalAdvisorSpecializationExists(int id)
        {
            return (_context.MedicalAdvisorSpecializations?.Any(e => e.MedicalAdvisorId == id)).GetValueOrDefault();
        }
    }
}
