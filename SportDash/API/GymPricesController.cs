using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;

namespace SportDash.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymPricesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GymPricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GymPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymPrices>>> GetGymPrices()
        {
            return await _context.GymPrices.ToListAsync();
        }

        // GET: api/GymPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymPrices>> GetGymPrices(int id)
        {
            var gymPrices = await _context.GymPrices.FindAsync(id);

            if (gymPrices == null)
            {
                return NotFound();
            }

            return gymPrices;
        }

        // PUT: api/GymPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymPrices(int id, GymPrices gymPrices)
        {
            if (id != gymPrices.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymPrices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymPricesExists(id))
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

        // POST: api/GymPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GymPrices>> PostGymPrices(GymPrices gymPrices)
        {
            _context.GymPrices.Add(gymPrices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGymPrices", new { id = gymPrices.Id }, gymPrices);
        }

        // DELETE: api/GymPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GymPrices>> DeleteGymPrices(int id)
        {
            var gymPrices = await _context.GymPrices.FindAsync(id);
            if (gymPrices == null)
            {
                return NotFound();
            }

            _context.GymPrices.Remove(gymPrices);
            await _context.SaveChangesAsync();

            return gymPrices;
        }

        private bool GymPricesExists(int id)
        {
            return _context.GymPrices.Any(e => e.Id == id);
        }
    }
}
