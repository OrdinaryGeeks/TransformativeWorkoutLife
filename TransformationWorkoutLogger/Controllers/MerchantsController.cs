﻿using System;
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
    public class MerchantsController : ControllerBase
    {
        private readonly DBContext _context;

        public MerchantsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Merchants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchant>>> GetMerchant()
        {
            return await _context.Merchant.ToListAsync();
        }

        // GET: api/Merchants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchant>> GetMerchant(int id)
        {
            var merchant = await _context.Merchant.FindAsync(id);

            if (merchant == null)
            {
                return NotFound();
            }

            return merchant;
        }

        // PUT: api/Merchants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchant(int id, Merchant merchant)
        {
            if (id != merchant.ID)
            {
                return BadRequest();
            }

            _context.Entry(merchant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantExists(id))
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

        // POST: api/Merchants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merchant>> PostMerchant(Merchant merchant)
        {
            _context.Merchant.Add(merchant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchant", new { id = merchant.ID }, merchant);
        }

        // DELETE: api/Merchants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var merchant = await _context.Merchant.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }

            _context.Merchant.Remove(merchant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchantExists(int id)
        {
            return _context.Merchant.Any(e => e.ID == id);
        }
    }
}
