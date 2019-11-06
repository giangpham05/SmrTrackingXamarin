using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMR.Tracking.DataAccess;
using SMR.Tracking.Domain;

namespace SMR.Tracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiRailLocationsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public HiRailLocationsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiRailLocation>>> GetHiRailLocations()
        {
            return await _context.HiRailLocations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HiRailLocation>> GetHiRailLocation(Guid id)
        {
            var hiRailLocation = await _context.HiRailLocations.FindAsync(id);

            if (hiRailLocation == null)
            {
                return NotFound();
            }

            return hiRailLocation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiRailLocation(Guid id, HiRailLocation hiRailLocation)
        {
            if (id != hiRailLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(hiRailLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiRailLocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<HiRailLocation>> PostHiRailLocation(HiRailLocation hiRailLocation)
        {
            _context.HiRailLocations.Add(hiRailLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHiRailLocation", new { id = hiRailLocation.Id }, hiRailLocation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HiRailLocation>> DeleteHiRailLocation(Guid id)
        {
            var hiRailLocation = await _context.HiRailLocations.FindAsync(id);
            if (hiRailLocation == null)
            {
                return NotFound();
            }

            _context.HiRailLocations.Remove(hiRailLocation);
            await _context.SaveChangesAsync();

            return hiRailLocation;
        }

        private bool HiRailLocationExists(Guid id)
        {
            return _context.HiRailLocations.Any(e => e.Id == id);
        }
    }
}
