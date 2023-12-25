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
    public class PlayerTrainingSessionsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerTrainingSessionsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerTrainingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerTrainingSession>>> GetPlayerTrainingSessions()
        {
            if (_context.PlayerTrainingSessions == null)
            {
                return NotFound();
            }
            return await _context.PlayerTrainingSessions.ToListAsync();
        }

        // GET: api/PlayerTrainingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerTrainingSession>> GetPlayerTrainingSession(int id)
        {
            if (_context.PlayerTrainingSessions == null)
            {
                return NotFound();
            }
            var playerTrainingSession = await _context.PlayerTrainingSessions.FindAsync(id);

            if (playerTrainingSession == null)
            {
                return NotFound();
            }

            return playerTrainingSession;
        }

        // PUT: api/PlayerTrainingSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerTrainingSession(int id, PlayerTrainingSession playerTrainingSession)
        {
            if (id != playerTrainingSession.PlayerTrainingSessionId)
            {
                return BadRequest();
            }

            _context.Entry(playerTrainingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerTrainingSessionExists(id))
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

        // POST: api/PlayerTrainingSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerTrainingSession>> PostPlayerTrainingSession(PlayerTrainingSession playerTrainingSession)
        {
            if (_context.PlayerTrainingSessions == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerTrainingSessions'  is null.");
            }
            _context.PlayerTrainingSessions.Add(playerTrainingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerTrainingSession", new { id = playerTrainingSession.PlayerTrainingSessionId }, playerTrainingSession);
        }

        // DELETE: api/PlayerTrainingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerTrainingSession(int id)
        {
            if (_context.PlayerTrainingSessions == null)
            {
                return NotFound();
            }
            var playerTrainingSession = await _context.PlayerTrainingSessions.FindAsync(id);
            if (playerTrainingSession == null)
            {
                return NotFound();
            }

            _context.PlayerTrainingSessions.Remove(playerTrainingSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerTrainingSessionExists(int id)
        {
            return (_context.PlayerTrainingSessions?.Any(e => e.PlayerTrainingSessionId == id)).GetValueOrDefault();
        }
    }
}
