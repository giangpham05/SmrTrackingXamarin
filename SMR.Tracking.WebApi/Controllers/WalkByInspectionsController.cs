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
    public class WalkByInspectionsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public WalkByInspectionsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalkByInspection>>> GetWalkByInspections()
        {
            return await _context.WalkByInspections.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalkByInspection>> GetWalkByInspection(Guid id)
        {
            var walkByInspection = await _context.WalkByInspections.FindAsync(id);

            if (walkByInspection == null)
            {
                return NotFound();
            }

            return walkByInspection;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalkByInspection(Guid id, WalkByInspection walkByInspection)
        {
            if (id != walkByInspection.Id)
            {
                return BadRequest();
            }

            _context.Entry(walkByInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalkByInspectionExists(id))
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
        public async Task<ActionResult<WalkByInspection>> PostWalkByInspection(WalkByInspection walkByInspection)
        {
            _context.WalkByInspections.Add(walkByInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWalkByInspection", new { id = walkByInspection.Id }, walkByInspection);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WalkByInspection>> DeleteWalkByInspection(Guid id)
        {
            var walkByInspection = await _context.WalkByInspections.FindAsync(id);
            if (walkByInspection == null)
            {
                return NotFound();
            }

            _context.WalkByInspections.Remove(walkByInspection);
            await _context.SaveChangesAsync();

            return walkByInspection;
        }

        private bool WalkByInspectionExists(Guid id)
        {
            return _context.WalkByInspections.Any(e => e.Id == id);
        }
    }
}
