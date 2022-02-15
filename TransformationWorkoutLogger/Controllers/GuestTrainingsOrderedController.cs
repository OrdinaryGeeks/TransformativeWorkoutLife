using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransformationWorkoutLife.Models;
using TransformationWorkoutLogger.Models;

namespace TransformationWorkoutLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestTrainingsOrderedController : ControllerBase
    {
        private readonly DBContext _context;

        public GuestTrainingsOrderedController(DBContext context)
        {
            _context = context;
        }

        // GET: api/GuestTrainingsOrdered
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestTrainingOrdered>>> GetGuestTrainingOrdered()
        {
            return await _context.GuestTrainingOrdered.ToListAsync();
        }

        // GET: api/GuestTrainingsOrdered/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestTrainingOrdered>> GetGuestTrainingOrdered(int id)
        {
            var guestTrainingOrdered = await _context.GuestTrainingOrdered.FindAsync(id);

            if (guestTrainingOrdered == null)
            {
                return NotFound();
            }

            return guestTrainingOrdered;
        }

        // PUT: api/GuestTrainingsOrdered/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestTrainingOrdered(int id, GuestTrainingOrdered guestTrainingOrdered)
        {
            if (id != guestTrainingOrdered.ID)
            {
                return BadRequest();
            }

            _context.Entry(guestTrainingOrdered).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestTrainingOrderedExists(id))
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

        // POST: api/GuestTrainingsOrdered
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuestTrainingOrdered>> PostGuestTrainingOrdered(GuestTrainingOrdered guestTrainingOrdered)
        {
            _context.GuestTrainingOrdered.Add(guestTrainingOrdered);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestTrainingOrdered", new { id = guestTrainingOrdered.ID }, guestTrainingOrdered);
        }

        // DELETE: api/GuestTrainingsOrdered/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestTrainingOrdered(int id)
        {
            var guestTrainingOrdered = await _context.GuestTrainingOrdered.FindAsync(id);
            if (guestTrainingOrdered == null)
            {
                return NotFound();
            }

            _context.GuestTrainingOrdered.Remove(guestTrainingOrdered);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestTrainingOrderedExists(int id)
        {
            return _context.GuestTrainingOrdered.Any(e => e.ID == id);
        }
    }
}
