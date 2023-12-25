using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Server.ViewModels;
using SportAcademy.BlazorApp.Shared.Models;

namespace SportAcademy.BlazorApp.Server.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;
        private readonly IWebHostEnvironment env;
        public TeamsController(SportsEdgeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
          if (_context.Teams == null)
          {
              return NotFound();
          }
            return await _context.Teams.ToListAsync();
        }
        [HttpGet("Players/Include")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsWithPlayers()
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            return await _context.Teams.Include(x=>x.Players).ToListAsync();
        }
        [HttpGet("Sports/Include")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsWithSports()
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            return await _context.Teams.Include(x => x.Sport).ToListAsync();
        }
        //
        [HttpGet("Sports")]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSport()
        {
            var sport= await _context.Sports.ToListAsync();
            return sport;
        }
        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
          if (_context.Teams == null)
          {
              return NotFound();
          }
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
          if (_context.Teams == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.Teams'  is null.");
          }
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("Upload/{id}")]
        public async Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            try
            {
                var team = await _context.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
                if (team == null) return NotFound();

                string ext = Path.GetExtension(file.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(this.env.WebRootPath, "Pictures", fileName);

                if (!Directory.Exists(Path.Combine(this.env.WebRootPath, "Pictures")))
                {
                    Directory.CreateDirectory(Path.Combine(this.env.WebRootPath, "Pictures"));
                }

                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                team.TeamLogo = fileName;
                await _context.SaveChangesAsync();
                return new UploadResponse { FileName = fileName };
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return BadRequest("Error uploading file");
            }
        }
        [HttpPost("Upload")]
        public async Task<UploadResponseModel> Upload(IFormFile file)
        {
            string ext = Path.GetExtension(file.FileName);
            string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
            //string s = env.WebRootPath;
            string savePath = Path.Combine(env.WebRootPath, "Pictures", f);
            using FileStream fs = new FileStream(savePath, FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            return new UploadResponseModel { ImageName = f };
        }
        private bool TeamExists(int id)
        {
            return (_context.Teams?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
