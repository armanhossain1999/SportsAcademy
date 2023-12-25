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
    public class PlayersController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;
        private readonly IWebHostEnvironment env;
        public PlayersController(SportsEdgeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
          if (_context.Players == null)
          {
              return NotFound();
          }
            return await _context.Players.ToListAsync();
        }
        // GET: api/Players
        [HttpGet("PlayerStatistics/Include")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersWithPlayerStatistics()
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var data = await _context.Players.Include(x=>x.PlayerStatistics).ToListAsync();
            return data;
        }
        [HttpGet("Team/Include")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersWithTeams()
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Include(x => x.Team).ToListAsync();
        }
        [HttpGet("Category/Include")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersWithCategories()
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Include(x => x.Category).ToListAsync();
        }
        [HttpGet("Teams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();

        }
        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
          if (_context.Players == null)
          {
              return NotFound();
          }
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }
        // GET: api/Players/5
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Player>> GetPlayerWithPlayerStatistic(int id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.Include(x=>x.PlayerStatistics).FirstOrDefaultAsync(x=>x.PlayerId == id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }
        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
          if (_context.Players == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.Players'  is null.");
          }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("Upload/{id}")]
        public async Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            try
            {
                var player = await _context.Players.FirstOrDefaultAsync(x => x.PlayerId == id);
                if (player == null) return NotFound();

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

                player.Picture = fileName;
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
        private bool PlayerExists(int id)
        {
            return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
