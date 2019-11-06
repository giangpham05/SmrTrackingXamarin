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
    public class RepairersController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public RepairersController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repairer>>> GetRepairers()
        {
            return await _context.Repairers.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Repairer>> GetRepairer(Guid id)
        {
            var repairer = await _context.Repairers.FindAsync(id);

            if (repairer == null)
            {
                return NotFound();
            }

            return repairer;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairer(Guid id, Repairer repairer)
        {
            if (id != repairer.Id)
            {
                return BadRequest();
            }

            _context.Entry(repairer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairerExists(id))
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
        public async Task<ActionResult<Repairer>> PostRepairer(Repairer repairer)
        {
            _context.Repairers.Add(repairer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairer", new { id = repairer.Id }, repairer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Repairer>> DeleteRepairer(Guid id)
        {
            var repairer = await _context.Repairers.FindAsync(id);
            if (repairer == null)
            {
                return NotFound();
            }

            _context.Repairers.Remove(repairer);
            await _context.SaveChangesAsync();

            return repairer;
        }

        private bool RepairerExists(Guid id)
        {
            return _context.Repairers.Any(e => e.Id == id);
        }
    }
}
