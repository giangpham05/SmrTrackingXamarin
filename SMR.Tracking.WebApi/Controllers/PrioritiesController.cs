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
    public class PrioritiesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public PrioritiesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Priority>>> GetPriorities()
        {
            return await _context.Priorities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Priority>> GetPriority(Guid id)
        {
            var priority = await _context.Priorities.FindAsync(id);

            if (priority == null)
            {
                return NotFound();
            }

            return priority;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriority(Guid id, Priority priority)
        {
            if (id != priority.Id)
            {
                return BadRequest();
            }

            _context.Entry(priority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(id))
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
        public async Task<ActionResult<Priority>> PostPriority(Priority priority)
        {
            _context.Priorities.Add(priority);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriority", new { id = priority.Id }, priority);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Priority>> DeletePriority(Guid id)
        {
            var priority = await _context.Priorities.FindAsync(id);
            if (priority == null)
            {
                return NotFound();
            }

            _context.Priorities.Remove(priority);
            await _context.SaveChangesAsync();

            return priority;
        }

        private bool PriorityExists(Guid id)
        {
            return _context.Priorities.Any(e => e.Id == id);
        }
    }
}
