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
    public class AtsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public AtsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AT>>> GetAts()
        {
            return await _context.Ats.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AT>> GetAT(Guid id)
        {
            var aT = await _context.Ats.FindAsync(id);

            if (aT == null)
            {
                return NotFound();
            }

            return aT;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAT(Guid id, AT aT)
        {
            if (id != aT.Id)
            {
                return BadRequest();
            }

            _context.Entry(aT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATExists(id))
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
        public async Task<ActionResult<AT>> PostAT(AT aT)
        {
            _context.Ats.Add(aT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAT", new { id = aT.Id }, aT);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AT>> DeleteAT(Guid id)
        {
            var aT = await _context.Ats.FindAsync(id);
            if (aT == null)
            {
                return NotFound();
            }

            _context.Ats.Remove(aT);
            await _context.SaveChangesAsync();

            return aT;
        }
        private bool ATExists(Guid id)
        {
            return _context.Ats.Any(e => e.Id == id);
        }
    }
}
