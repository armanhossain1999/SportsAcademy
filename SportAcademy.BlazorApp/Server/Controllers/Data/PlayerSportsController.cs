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
    public class PlayerSportsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerSportsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerSports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerSport>>> GetPlayerSports()
        {
            if (_context.PlayerSports == null)
            {
                return NotFound();
            }
            return await _context.PlayerSports.ToListAsync();
        }

        // GET: api/PlayerSports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerSport>> GetPlayerSport(int id)
        {
            if (_context.PlayerSports == null)
            {
                return NotFound();
            }
            var playerSport = await _context.PlayerSports.FindAsync(id);

            if (playerSport == null)
            {
                return NotFound();
            }

            return playerSport;
        }

        // PUT: api/PlayerSports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerSport(int id, PlayerSport playerSport)
        {
            if (id != playerSport.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerSport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerSportExists(id))
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

        // POST: api/PlayerSports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerSport>> PostPlayerSport(PlayerSport playerSport)
        {
            if (_context.PlayerSports == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerSports'  is null.");
            }
            _context.PlayerSports.Add(playerSport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerSportExists(playerSport.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerSport", new { id = playerSport.PlayerId }, playerSport);
        }

        // DELETE: api/PlayerSports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerSport(int id)
        {
            if (_context.PlayerSports == null)
            {
                return NotFound();
            }
            var playerSport = await _context.PlayerSports.FindAsync(id);
            if (playerSport == null)
            {
                return NotFound();
            }

            _context.PlayerSports.Remove(playerSport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerSportExists(int id)
        {
            return (_context.PlayerSports?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
