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
    public class GuestOrdersController : ControllerBase
    {
        private readonly DBContext _context;

        public GuestOrdersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/GuestOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestOrder>>> GetGuestOrder()
        {
            return await _context.GuestOrder.ToListAsync();
        }

        // GET: api/GuestOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestOrder>> GetGuestOrder(int id)
        {
            var guestOrder = await _context.GuestOrder.FindAsync(id);

            if (guestOrder == null)
            {
                return NotFound();
            }

            return guestOrder;
        }

        // PUT: api/GuestOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestOrder(int id, GuestOrder guestOrder)
        {
            if (id != guestOrder.ID)
            {
                return BadRequest();
            }

            _context.Entry(guestOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestOrderExists(id))
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

        // POST: api/GuestOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuestOrder>> PostGuestOrder(GuestOrder guestOrder)
        {
            _context.GuestOrder.Add(guestOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestOrder", new { id = guestOrder.ID }, guestOrder);
        }

        // DELETE: api/GuestOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestOrder(int id)
        {
            var guestOrder = await _context.GuestOrder.FindAsync(id);
            if (guestOrder == null)
            {
                return NotFound();
            }

            _context.GuestOrder.Remove(guestOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestOrderExists(int id)
        {
            return _context.GuestOrder.Any(e => e.ID == id);
        }
    }
}
