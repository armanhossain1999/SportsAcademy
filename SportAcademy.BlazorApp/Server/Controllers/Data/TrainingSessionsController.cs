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
    public class TrainingSessionsController : ControllerBase
    {
        private readonly SportsEdgeDbContext _context;

        public TrainingSessionsController(SportsEdgeDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingSession>>> GetTrainingSessions()
        {
            if (_context.TrainingSessions == null)
            {
                return NotFound();
            }
            return await _context.TrainingSessions.ToListAsync();
        }
        [HttpGet("Coaches")]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
            return await _context.Coaches.ToListAsync();
        }
        // GET: api/TrainingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingSession>> GetTrainingSession(int id)
        {
            if (_context.TrainingSessions == null)
            {
                return NotFound();
            }
            var trainingSession = await _context.TrainingSessions.FindAsync(id);

            if (trainingSession == null)
            {
                return NotFound();
            }

            return trainingSession;
        }

        // PUT: api/TrainingSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingSession(int id, TrainingSession trainingSession)
        {
            if (id != trainingSession.TrainingSessionId)
            {
                return BadRequest();
            }

            _context.Entry(trainingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingSessionExists(id))
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

        // POST: api/TrainingSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingSession>> PostTrainingSession(TrainingSession trainingSession)
        {
            if (_context.TrainingSessions == null)
            {
                return Problem("Entity set 'SportsEdgeDbContext.TrainingSessions'  is null.");
            }
            _context.TrainingSessions.Add(trainingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingSession", new { id = trainingSession.TrainingSessionId }, trainingSession);
        }

        // DELETE: api/TrainingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSession(int id)
        {
            if (_context.TrainingSessions == null)
            {
                return NotFound();
            }
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }

            _context.TrainingSessions.Remove(trainingSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingSessionExists(int id)
        {
            return (_context.TrainingSessions?.Any(e => e.TrainingSessionId == id)).GetValueOrDefault();
        }
    }
}
