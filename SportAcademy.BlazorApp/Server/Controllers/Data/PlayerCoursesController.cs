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
    public class PlayerCoursesController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public PlayerCoursesController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerCourse>>> GetPlayerCourses()
        {
            if (_context.PlayerCourses == null)
            {
                return NotFound();
            }
            return await _context.PlayerCourses.ToListAsync();
        }

        // GET: api/PlayerCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerCourse>> GetPlayerCourse(int id)
        {
            if (_context.PlayerCourses == null)
            {
                return NotFound();
            }
            var playerCourse = await _context.PlayerCourses.FindAsync(id);

            if (playerCourse == null)
            {
                return NotFound();
            }

            return playerCourse;
        }

        // PUT: api/PlayerCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerCourse(int id, PlayerCourse playerCourse)
        {
            if (id != playerCourse.PlayerCourseId)
            {
                return BadRequest();
            }

            _context.Entry(playerCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerCourseExists(id))
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

        // POST: api/PlayerCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerCourse>> PostPlayerCourse(PlayerCourse playerCourse)
        {
            if (_context.PlayerCourses == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.PlayerCourses'  is null.");
            }
            _context.PlayerCourses.Add(playerCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerCourse", new { id = playerCourse.PlayerCourseId }, playerCourse);
        }

        // DELETE: api/PlayerCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerCourse(int id)
        {
            if (_context.PlayerCourses == null)
            {
                return NotFound();
            }
            var playerCourse = await _context.PlayerCourses.FindAsync(id);
            if (playerCourse == null)
            {
                return NotFound();
            }

            _context.PlayerCourses.Remove(playerCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerCourseExists(int id)
        {
            return (_context.PlayerCourses?.Any(e => e.PlayerCourseId == id)).GetValueOrDefault();
        }
    }
}
