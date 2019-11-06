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
    public class InspectorsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public InspectorsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspector>>> GetInspectors()
        {
            return await _context.Inspectors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inspector>> GetInspector(Guid id)
        {
            var inspector = await _context.Inspectors.FindAsync(id);

            if (inspector == null)
            {
                return NotFound();
            }

            return inspector;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspector(Guid id, Inspector inspector)
        {
            if (id != inspector.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectorExists(id))
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
        public async Task<ActionResult<Inspector>> PostInspector(Inspector inspector)
        {
            _context.Inspectors.Add(inspector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspector", new { id = inspector.Id }, inspector);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Inspector>> DeleteInspector(Guid id)
        {
            var inspector = await _context.Inspectors.FindAsync(id);
            if (inspector == null)
            {
                return NotFound();
            }

            _context.Inspectors.Remove(inspector);
            await _context.SaveChangesAsync();

            return inspector;
        }

        private bool InspectorExists(Guid id)
        {
            return _context.Inspectors.Any(e => e.Id == id);
        }
    }
}
