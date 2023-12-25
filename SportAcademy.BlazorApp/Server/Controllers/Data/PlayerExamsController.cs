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
    public class PlayerExamsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerExamsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerExams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerExam>>> GetPlayerExams()
        {
            if (_context.PlayerExams == null)
            {
                return NotFound();
            }
            return await _context.PlayerExams.ToListAsync();
        }

        // GET: api/PlayerExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerExam>> GetPlayerExam(int id)
        {
            if (_context.PlayerExams == null)
            {
                return NotFound();
            }
            var playerExam = await _context.PlayerExams.FindAsync(id);

            if (playerExam == null)
            {
                return NotFound();
            }

            return playerExam;
        }

        // PUT: api/PlayerExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerExam(int id, PlayerExam playerExam)
        {
            if (id != playerExam.PlayerExamId)
            {
                return BadRequest();
            }

            _context.Entry(playerExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExamExists(id))
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

        // POST: api/PlayerExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerExam>> PostPlayerExam(PlayerExam playerExam)
        {
            if (_context.PlayerExams == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerExams'  is null.");
            }
            _context.PlayerExams.Add(playerExam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerExam", new { id = playerExam.PlayerExamId }, playerExam);
        }

        // DELETE: api/PlayerExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerExam(int id)
        {
            if (_context.PlayerExams == null)
            {
                return NotFound();
            }
            var playerExam = await _context.PlayerExams.FindAsync(id);
            if (playerExam == null)
            {
                return NotFound();
            }

            _context.PlayerExams.Remove(playerExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExamExists(int id)
        {
            return (_context.PlayerExams?.Any(e => e.PlayerExamId == id)).GetValueOrDefault();
        }
    }
}
