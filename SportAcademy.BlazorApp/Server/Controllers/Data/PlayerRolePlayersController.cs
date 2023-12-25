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
    public class PlayerRolePlayersController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerRolePlayersController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerRolePlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerRolePlayer>>> GetPlayerRolePlayers()
        {
            if (_context.PlayerRolePlayers == null)
            {
                return NotFound();
            }
            return await _context.PlayerRolePlayers.ToListAsync();
        }

        // GET: api/PlayerRolePlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerRolePlayer>> GetPlayerRolePlayer(int id)
        {
            if (_context.PlayerRolePlayers == null)
            {
                return NotFound();
            }
            var playerRolePlayer = await _context.PlayerRolePlayers.FindAsync(id);

            if (playerRolePlayer == null)
            {
                return NotFound();
            }

            return playerRolePlayer;
        }

        // PUT: api/PlayerRolePlayers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerRolePlayer(int id, PlayerRolePlayer playerRolePlayer)
        {
            if (id != playerRolePlayer.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerRolePlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerRolePlayerExists(id))
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

        // POST: api/PlayerRolePlayers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerRolePlayer>> PostPlayerRolePlayer(PlayerRolePlayer playerRolePlayer)
        {
            if (_context.PlayerRolePlayers == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerRolePlayers'  is null.");
            }
            _context.PlayerRolePlayers.Add(playerRolePlayer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerRolePlayerExists(playerRolePlayer.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerRolePlayer", new { id = playerRolePlayer.PlayerId }, playerRolePlayer);
        }

        // DELETE: api/PlayerRolePlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerRolePlayer(int id)
        {
            if (_context.PlayerRolePlayers == null)
            {
                return NotFound();
            }
            var playerRolePlayer = await _context.PlayerRolePlayers.FindAsync(id);
            if (playerRolePlayer == null)
            {
                return NotFound();
            }

            _context.PlayerRolePlayers.Remove(playerRolePlayer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerRolePlayerExists(int id)
        {
            return (_context.PlayerRolePlayers?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
