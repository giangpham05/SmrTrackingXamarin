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
    public class LocationPrefixesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public LocationPrefixesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationPrefix>>> GetLocationPrefixes()
        {
            return await _context.LocationPrefixes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationPrefix>> GetLocationPrefix(Guid id)
        {
            var locationPrefix = await _context.LocationPrefixes.FindAsync(id);

            if (locationPrefix == null)
            {
                return NotFound();
            }

            return locationPrefix;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationPrefix(Guid id, LocationPrefix locationPrefix)
        {
            if (id != locationPrefix.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationPrefix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationPrefixExists(id))
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
        public async Task<ActionResult<LocationPrefix>> PostLocationPrefix(LocationPrefix locationPrefix)
        {
            _context.LocationPrefixes.Add(locationPrefix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationPrefix", new { id = locationPrefix.Id }, locationPrefix);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationPrefix>> DeleteLocationPrefix(Guid id)
        {
            var locationPrefix = await _context.LocationPrefixes.FindAsync(id);
            if (locationPrefix == null)
            {
                return NotFound();
            }

            _context.LocationPrefixes.Remove(locationPrefix);
            await _context.SaveChangesAsync();

            return locationPrefix;
        }

        private bool LocationPrefixExists(Guid id)
        {
            return _context.LocationPrefixes.Any(e => e.Id == id);
        }
    }
}
