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
    public class PlayerStatisticsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerStatisticsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerStatistic>>> GetPlayerStatistics()
        {
            if (_context.PlayerStatistics == null)
            {
                return NotFound();
            }
            return await _context.PlayerStatistics.ToListAsync();
        }
        // GET: api/PlayerStatistics
        [HttpGet("PLayerStateDetails/Include")]
        public async Task<ActionResult<IEnumerable<PlayerStatistic>>> GetPlayerStatisticsWithPLayerStateDetails()
        {
            if (_context.PlayerStatistics == null)
            {
                return NotFound();
            }
            return await _context.PlayerStatistics.Include(x=>x.PlayerStateDetails).ToListAsync();
        }
        // GET: api/PlayerStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerStatistic>> GetPlayerStatistic(int id)
        {
            if (_context.PlayerStatistics == null)
            {
                return NotFound();
            }
            var playerStatistic = await _context.PlayerStatistics.FindAsync(id);

            if (playerStatistic == null)
            {
                return NotFound();
            }

            return playerStatistic;
        }

        // PUT: api/PlayerStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerStatistic(int id, PlayerStatistic playerStatistic)
        {
            if (id != playerStatistic.PlayerStatisticId)
            {
                return BadRequest();
            }

            _context.Entry(playerStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStatisticExists(id))
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

        // POST: api/PlayerStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerStatistic>> PostPlayerStatistic(PlayerStatistic playerStatistic)
        {
            if (_context.PlayerStatistics == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerStatistics'  is null.");
            }
            _context.PlayerStatistics.Add(playerStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerStatistic", new { id = playerStatistic.PlayerStatisticId }, playerStatistic);
        }

        // DELETE: api/PlayerStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerStatistic(int id)
        {
            if (_context.PlayerStatistics == null)
            {
                return NotFound();
            }
            var playerStatistic = await _context.PlayerStatistics.FindAsync(id);
            if (playerStatistic == null)
            {
                return NotFound();
            }

            _context.PlayerStatistics.Remove(playerStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerStatisticExists(int id)
        {
            return (_context.PlayerStatistics?.Any(e => e.PlayerStatisticId == id)).GetValueOrDefault();
        }
    }
}
