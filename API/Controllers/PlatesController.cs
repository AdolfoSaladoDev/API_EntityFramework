using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatesController : ControllerBase
    {
        private readonly MenuContext _context;

        public PlatesController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/Plates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plate>>> GetPlates()
        {
          if (_context.Plates == null)
          {
              return NotFound();
          }
            return await _context.Plates.ToListAsync();
        }

        // GET: api/Plates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plate>> GetPlate(int id)
        {
          if (_context.Plates == null)
          {
              return NotFound();
          }
            var plate = await _context.Plates.FindAsync(id);

            if (plate == null)
            {
                return NotFound();
            }

            return plate;
        }

        // PUT: api/Plates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlate(int id, Plate plate)
        {
            if (id != plate.Id)
            {
                return BadRequest();
            }

            _context.Entry(plate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlateExists(id))
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

        // POST: api/Plates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plate>> PostPlate(Plate plate)
        {
          if (_context.Plates == null)
          {
              return Problem("Entity set 'MenuContext.Plates'  is null.");
          }
            _context.Plates.Add(plate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlate", new { id = plate.Id }, plate);
        }

        // DELETE: api/Plates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlate(int id)
        {
            if (_context.Plates == null)
            {
                return NotFound();
            }
            var plate = await _context.Plates.FindAsync(id);
            if (plate == null)
            {
                return NotFound();
            }

            _context.Plates.Remove(plate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlateExists(int id)
        {
            return (_context.Plates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
