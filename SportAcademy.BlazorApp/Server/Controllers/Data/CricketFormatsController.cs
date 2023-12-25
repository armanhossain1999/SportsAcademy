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
    public class CricketFormatsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public CricketFormatsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/CricketFormats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CricketFormat>>> GetCricketFormats()
        {
            if (_context.CricketFormats == null)
            {
                return NotFound();
            }
            return await _context.CricketFormats.ToListAsync();
        }

        // GET: api/CricketFormats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CricketFormat>> GetCricketFormat(int id)
        {
            if (_context.CricketFormats == null)
            {
                return NotFound();
            }
            var cricketFormat = await _context.CricketFormats.FindAsync(id);

            if (cricketFormat == null)
            {
                return NotFound();
            }

            return cricketFormat;
        }

        // PUT: api/CricketFormats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCricketFormat(int id, CricketFormat cricketFormat)
        {
            if (id != cricketFormat.CricketFormatId)
            {
                return BadRequest();
            }

            _context.Entry(cricketFormat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CricketFormatExists(id))
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

        // POST: api/CricketFormats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CricketFormat>> PostCricketFormat(CricketFormat cricketFormat)
        {
            if (_context.CricketFormats == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.CricketFormats'  is null.");
            }
            _context.CricketFormats.Add(cricketFormat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCricketFormat", new { id = cricketFormat.CricketFormatId }, cricketFormat);
        }

        // DELETE: api/CricketFormats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCricketFormat(int id)
        {
            if (_context.CricketFormats == null)
            {
                return NotFound();
            }
            var cricketFormat = await _context.CricketFormats.FindAsync(id);
            if (cricketFormat == null)
            {
                return NotFound();
            }

            _context.CricketFormats.Remove(cricketFormat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CricketFormatExists(int id)
        {
            return (_context.CricketFormats?.Any(e => e.CricketFormatId == id)).GetValueOrDefault();
        }
    }
}
