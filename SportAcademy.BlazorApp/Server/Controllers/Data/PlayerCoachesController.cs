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
    public class PlayerCoachesController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerCoachesController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerCoaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerCoach>>> GetPlayerCoaches()
        {
            if (_context.PlayerCoaches == null)
            {
                return NotFound();
            }
            return await _context.PlayerCoaches.ToListAsync();
        }

        // GET: api/PlayerCoaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerCoach>> GetPlayerCoach(int id)
        {
            if (_context.PlayerCoaches == null)
            {
                return NotFound();
            }
            var playerCoach = await _context.PlayerCoaches.FindAsync(id);

            if (playerCoach == null)
            {
                return NotFound();
            }

            return playerCoach;
        }

        // PUT: api/PlayerCoaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerCoach(int id, PlayerCoach playerCoach)
        {
            if (id != playerCoach.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerCoach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerCoachExists(id))
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

        // POST: api/PlayerCoaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerCoach>> PostPlayerCoach(PlayerCoach playerCoach)
        {
            if (_context.PlayerCoaches == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerCoaches'  is null.");
            }
            _context.PlayerCoaches.Add(playerCoach);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerCoachExists(playerCoach.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerCoach", new { id = playerCoach.PlayerId }, playerCoach);
        }

        // DELETE: api/PlayerCoaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerCoach(int id)
        {
            if (_context.PlayerCoaches == null)
            {
                return NotFound();
            }
            var playerCoach = await _context.PlayerCoaches.FindAsync(id);
            if (playerCoach == null)
            {
                return NotFound();
            }

            _context.PlayerCoaches.Remove(playerCoach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerCoachExists(int id)
        {
            return (_context.PlayerCoaches?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
