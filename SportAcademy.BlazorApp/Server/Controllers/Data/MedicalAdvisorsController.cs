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
    public class MedicalAdvisorsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public MedicalAdvisorsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalAdvisors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalAdvisor>>> GetMedicalAdvisors()
        {
          if (_context.MedicalAdvisors == null)
          {
              return NotFound();
          }
            return await _context.MedicalAdvisors.ToListAsync();
        }

        // GET: api/MedicalAdvisors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalAdvisor>> GetMedicalAdvisor(int id)
        {
          if (_context.MedicalAdvisors == null)
          {
              return NotFound();
          }
            var medicalAdvisor = await _context.MedicalAdvisors.FindAsync(id);

            if (medicalAdvisor == null)
            {
                return NotFound();
            }

            return medicalAdvisor;
        }

        // PUT: api/MedicalAdvisors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalAdvisor(int id, MedicalAdvisor medicalAdvisor)
        {
            if (id != medicalAdvisor.MedicalAdvisorId)
            {
                return BadRequest();
            }

            _context.Entry(medicalAdvisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalAdvisorExists(id))
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

        // POST: api/MedicalAdvisors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalAdvisor>> PostMedicalAdvisor(MedicalAdvisor medicalAdvisor)
        {
          if (_context.MedicalAdvisors == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.MedicalAdvisors'  is null.");
          }
            _context.MedicalAdvisors.Add(medicalAdvisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalAdvisor", new { id = medicalAdvisor.MedicalAdvisorId }, medicalAdvisor);
        }

        // DELETE: api/MedicalAdvisors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalAdvisor(int id)
        {
            if (_context.MedicalAdvisors == null)
            {
                return NotFound();
            }
            var medicalAdvisor = await _context.MedicalAdvisors.FindAsync(id);
            if (medicalAdvisor == null)
            {
                return NotFound();
            }

            _context.MedicalAdvisors.Remove(medicalAdvisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalAdvisorExists(int id)
        {
            return (_context.MedicalAdvisors?.Any(e => e.MedicalAdvisorId == id)).GetValueOrDefault();
        }
    }
}
