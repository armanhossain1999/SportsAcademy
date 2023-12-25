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
    public class ExamResultsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public ExamResultsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamResult>>> GetExamResults()
        {
            if (_context.ExamResults == null)
            {
                return NotFound();
            }
            return await _context.ExamResults.ToListAsync();
        }

        // GET: api/ExamResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamResult>> GetExamResult(int id)
        {
            if (_context.ExamResults == null)
            {
                return NotFound();
            }
            var examResult = await _context.ExamResults.FindAsync(id);

            if (examResult == null)
            {
                return NotFound();
            }

            return examResult;
        }

        // PUT: api/ExamResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamResult(int id, ExamResult examResult)
        {
            if (id != examResult.ExamResultId)
            {
                return BadRequest();
            }

            _context.Entry(examResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamResultExists(id))
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

        // POST: api/ExamResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamResult>> PostExamResult(ExamResult examResult)
        {
            if (_context.ExamResults == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.ExamResults'  is null.");
            }
            _context.ExamResults.Add(examResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamResult", new { id = examResult.ExamResultId }, examResult);
        }

        // DELETE: api/ExamResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamResult(int id)
        {
            if (_context.ExamResults == null)
            {
                return NotFound();
            }
            var examResult = await _context.ExamResults.FindAsync(id);
            if (examResult == null)
            {
                return NotFound();
            }

            _context.ExamResults.Remove(examResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamResultExists(int id)
        {
            return (_context.ExamResults?.Any(e => e.ExamResultId == id)).GetValueOrDefault();
        }
    }
}
