using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransformationWorkoutLife.Models;

namespace TransformationWorkoutLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogBlurbsController : ControllerBase
    {
        private readonly DBContext _context;

        public BlogBlurbsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/BlogBlurbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogBlurb>>> GetBlogBlurb()
        {
            return await _context.BlogBlurb.ToListAsync();
        }

        // GET: api/BlogBlurbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogBlurb>> GetBlogBlurb(int id)
        {
            var blogBlurb = await _context.BlogBlurb.FindAsync(id);

            if (blogBlurb == null)
            {
                return NotFound();
            }

            return blogBlurb;
        }

        // PUT: api/BlogBlurbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogBlurb(int id, BlogBlurb blogBlurb)
        {
            if (id != blogBlurb.ID)
            {
                return BadRequest();
            }

            _context.Entry(blogBlurb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogBlurbExists(id))
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

        // POST: api/BlogBlurbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogBlurb>> PostBlogBlurb(BlogBlurb blogBlurb)
        {
            _context.BlogBlurb.Add(blogBlurb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogBlurb", new { id = blogBlurb.ID }, blogBlurb);
        }

        // DELETE: api/BlogBlurbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogBlurb(int id)
        {
            var blogBlurb = await _context.BlogBlurb.FindAsync(id);
            if (blogBlurb == null)
            {
                return NotFound();
            }

            _context.BlogBlurb.Remove(blogBlurb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogBlurbExists(int id)
        {
            return _context.BlogBlurb.Any(e => e.ID == id);
        }
    }
}
