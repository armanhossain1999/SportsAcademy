using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Shared.Models;
using SportAcademy.BlazorApp.Server.ViewModels;

namespace SportAcademy.BlazorApp.Server.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin, Staff")]
    public class ManagersController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;
        private readonly IWebHostEnvironment env;
        public ManagersController(SportsEdgeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            var managers = await _context.Managers.ToListAsync();
            if (managers == null || managers.Count == 0)
            {
                return NotFound("No managers found.");
            }

            return managers;
        }

        // GET: api/Managers/Events/Include
        [HttpGet("Events/Include")]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagersWithEvents()
        {
            var managers = await _context.Managers.Include(x => x.Events)  .ToListAsync();

            if (managers == null || managers.Count == 0)
            {
                return NotFound("No managers found.");
            }

            return managers;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
          if (_context.Managers == null)
          {
              return NotFound();
          }
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Manager>> GetManagerWithEvent(int id)
        {
            if (_context.Managers == null)
            {
                return NotFound();
            }
            var manager = await _context.Managers
                    .Include(x => x.Events)
                    .FirstOrDefaultAsync(x => x.ManagerId == id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }
        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            if (id != manager.ManagerId)
            {
                return BadRequest();
            }

            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
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

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
          if (_context.Managers == null)
          {
              return Problem("Entity set 'SportsEdgeDbContext.Managers'  is null.");
          }
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManager", new { id = manager.ManagerId }, manager);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            if (_context.Managers == null)
            {
                return NotFound();
            }
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Upload Image for Angular
        [HttpPost("Upload/{id}")]
        public async Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            try
            {
                var manager = await _context.Managers.FirstOrDefaultAsync(x => x.ManagerId == id);
                if (manager == null) return NotFound();

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

                manager.Picture = fileName;
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
        //Upload Image for Blazor
        [HttpPost("Upload")]
        public async Task<UploadResponseModel> UploadManager(IFormFile file)
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
        private bool ManagerExists(int id)
        {
            return (_context.Managers?.Any(e => e.ManagerId == id)).GetValueOrDefault();
        }
    }
}
