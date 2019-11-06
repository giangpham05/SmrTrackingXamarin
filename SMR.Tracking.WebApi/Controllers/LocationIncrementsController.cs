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
    public class LocationIncrementsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public LocationIncrementsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationIncrement>>> GetLocationIncrements()
        {
            return await _context.LocationIncrements.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationIncrement>> GetLocationIncrement(Guid id)
        {
            var locationIncrement = await _context.LocationIncrements.FindAsync(id);

            if (locationIncrement == null)
            {
                return NotFound();
            }

            return locationIncrement;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationIncrement(Guid id, LocationIncrement locationIncrement)
        {
            if (id != locationIncrement.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationIncrement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationIncrementExists(id))
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
        public async Task<ActionResult<LocationIncrement>> PostLocationIncrement(LocationIncrement locationIncrement)
        {
            _context.LocationIncrements.Add(locationIncrement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationIncrement", new { id = locationIncrement.Id }, locationIncrement);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationIncrement>> DeleteLocationIncrement(Guid id)
        {
            var locationIncrement = await _context.LocationIncrements.FindAsync(id);
            if (locationIncrement == null)
            {
                return NotFound();
            }

            _context.LocationIncrements.Remove(locationIncrement);
            await _context.SaveChangesAsync();

            return locationIncrement;
        }

        private bool LocationIncrementExists(Guid id)
        {
            return _context.LocationIncrements.Any(e => e.Id == id);
        }
    }
}
