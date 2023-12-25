using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAcademy.BlazorApp.Shared.Models;
using SportAcademy.BlazorApp.Server.ViewModels;

namespace SportAcademy.BlazorApp.Server.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;
        private readonly IWebHostEnvironment env;
        public EventsController(SportsEdgeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events.ToListAsync();
        }
        [HttpGet("Manager/Include")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsWithManagers()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events.Include(x=>x.Manager).ToListAsync();
        }
        [HttpGet("SelectionPanel/Include")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsWithSelectionPanel()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events.Include(x => x.SelectionPanel).ToListAsync();
        }
        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }
        [HttpGet("{id}/Manager/Include")]
        public async Task<ActionResult<Event>> GetEventWithManager(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.Include(x=>x.Manager).FirstOrDefaultAsync(x=>x.EventId==id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }
        [HttpGet("{id}/SelectionPanel/Include")]
        public async Task<ActionResult<Event>> GetEventWithSelectionPanel(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.Include(x => x.SelectionPanel).FirstOrDefaultAsync(x => x.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }
        //
        [HttpGet("Managers")]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        [HttpGet("SelectionPanels")]
        public async Task<ActionResult<IEnumerable<SelectionPanel>>> GetSelectionPanels()
        {
            return await _context.SelectionPanels.ToListAsync();
        }
        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.Events'  is null.");
            }
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return (_context.Events?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
        [HttpPost("Upload/{id}")]
        public async Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            var events = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);

            if (events == null) return NotFound();

            string ext = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
            string savePath = Path.Combine(this.env.WebRootPath, "Pictures", fileName);
            if (!Directory.Exists(Path.Combine(this.env.WebRootPath, "Pictures")))
            {
                Directory.CreateDirectory(Path.Combine(this.env.WebRootPath, "Pictures"));
            }
            FileStream fs = new FileStream(savePath, FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            events.Picture = fileName;
            await _context.SaveChangesAsync();
            return new UploadResponse { FileName = fileName };
        }
        private bool ManagerExists(int id)
        {
            return (_context.Managers?.Any(e => e.ManagerId == id)).GetValueOrDefault();
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
    }
}

