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
    public class PlayerStateDetailsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerStateDetailsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerStateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerStateDetail>>> GetPlayerStateDetails()
        {
            if (_context.PlayerStateDetails == null)
            {
                return NotFound();
            }
            return await _context.PlayerStateDetails.ToListAsync();
        }

        // GET: api/PlayerStateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerStateDetail>> GetPlayerStateDetail(int id)
        {
            if (_context.PlayerStateDetails == null)
            {
                return NotFound();
            }
            var playerStateDetail = await _context.PlayerStateDetails.FindAsync(id);

            if (playerStateDetail == null)
            {
                return NotFound();
            }

            return playerStateDetail;
        }

        // PUT: api/PlayerStateDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerStateDetail(int id, PlayerStateDetail playerStateDetail)
        {
            if (id != playerStateDetail.PlayerStateDetailId)
            {
                return BadRequest();
            }

            _context.Entry(playerStateDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStateDetailExists(id))
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

        // POST: api/PlayerStateDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerStateDetail>> PostPlayerStateDetail(PlayerStateDetail playerStateDetail)
        {
            if (_context.PlayerStateDetails == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerStateDetails'  is null.");
            }
            _context.PlayerStateDetails.Add(playerStateDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerStateDetail", new { id = playerStateDetail.PlayerStateDetailId }, playerStateDetail);
        }

        // DELETE: api/PlayerStateDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerStateDetail(int id)
        {
            if (_context.PlayerStateDetails == null)
            {
                return NotFound();
            }
            var playerStateDetail = await _context.PlayerStateDetails.FindAsync(id);
            if (playerStateDetail == null)
            {
                return NotFound();
            }

            _context.PlayerStateDetails.Remove(playerStateDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerStateDetailExists(int id)
        {
            return (_context.PlayerStateDetails?.Any(e => e.PlayerStateDetailId == id)).GetValueOrDefault();
        }
    }
}
