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
    public class PlayerRolesController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerRolesController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerRole>>> GetPlayerRoles()
        {
            if (_context.PlayerRoles == null)
            {
                return NotFound();
            }
            return await _context.PlayerRoles.ToListAsync();
        }
        // GET: api/PlayerRoles
        [HttpGet("PlayerRolePlayers/Include")]
        public async Task<ActionResult<IEnumerable<PlayerRole>>> GetPlayerRolesWithPlayers()
        {
            if (_context.PlayerRoles == null)
            {
                return NotFound();
            }
            return await _context.PlayerRoles.Include(x=>x.PlayerRolePlayers).ToListAsync();
        }
        // GET: api/PlayerRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerRole>> GetPlayerRole(int id)
        {
            if (_context.PlayerRoles == null)
            {
                return NotFound();
            }
            var playerRole = await _context.PlayerRoles.FindAsync(id);

            if (playerRole == null)
            {
                return NotFound();
            }

            return playerRole;
        }

        // PUT: api/PlayerRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerRole(int id, PlayerRole playerRole)
        {
            if (id != playerRole.PlayerRoleId)
            {
                return BadRequest();
            }

            _context.Entry(playerRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerRoleExists(id))
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

        // POST: api/PlayerRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerRole>> PostPlayerRole(PlayerRole playerRole)
        {
            if (_context.PlayerRoles == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerRoles'  is null.");
            }
            _context.PlayerRoles.Add(playerRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerRole", new { id = playerRole.PlayerRoleId }, playerRole);
        }

        // DELETE: api/PlayerRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerRole(int id)
        {
            if (_context.PlayerRoles == null)
            {
                return NotFound();
            }
            var playerRole = await _context.PlayerRoles.FindAsync(id);
            if (playerRole == null)
            {
                return NotFound();
            }

            _context.PlayerRoles.Remove(playerRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerRoleExists(int id)
        {
            return (_context.PlayerRoles?.Any(e => e.PlayerRoleId == id)).GetValueOrDefault();
        }
    }
}
