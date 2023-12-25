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
    public class ExamTypeExamsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public ExamTypeExamsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamTypeExams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamTypeExam>>> GetExamTypeExams()
        {
            if (_context.ExamTypeExams == null)
            {
                return NotFound();
            }
            return await _context.ExamTypeExams.ToListAsync();
        }

        // GET: api/ExamTypeExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamTypeExam>> GetExamTypeExam(int id)
        {
            if (_context.ExamTypeExams == null)
            {
                return NotFound();
            }
            var examTypeExam = await _context.ExamTypeExams.FindAsync(id);

            if (examTypeExam == null)
            {
                return NotFound();
            }

            return examTypeExam;
        }

        // PUT: api/ExamTypeExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamTypeExam(int id, ExamTypeExam examTypeExam)
        {
            if (id != examTypeExam.ExamId)
            {
                return BadRequest();
            }

            _context.Entry(examTypeExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamTypeExamExists(id))
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

        // POST: api/ExamTypeExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamTypeExam>> PostExamTypeExam(ExamTypeExam examTypeExam)
        {
            if (_context.ExamTypeExams == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.ExamTypeExams'  is null.");
            }
            _context.ExamTypeExams.Add(examTypeExam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamTypeExamExists(examTypeExam.ExamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExamTypeExam", new { id = examTypeExam.ExamId }, examTypeExam);
        }

        // DELETE: api/ExamTypeExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamTypeExam(int id)
        {
            if (_context.ExamTypeExams == null)
            {
                return NotFound();
            }
            var examTypeExam = await _context.ExamTypeExams.FindAsync(id);
            if (examTypeExam == null)
            {
                return NotFound();
            }

            _context.ExamTypeExams.Remove(examTypeExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamTypeExamExists(int id)
        {
            return (_context.ExamTypeExams?.Any(e => e.ExamId == id)).GetValueOrDefault();
        }
    }
}
