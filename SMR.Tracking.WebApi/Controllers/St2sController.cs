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
    public class St2sController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public St2sController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ST2>>> GetSt2s()
        {
            return await _context.St2s.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ST2>> GetST2(Guid id)
        {
            var sT2 = await _context.St2s.FindAsync(id);

            if (sT2 == null)
            {
                return NotFound();
            }

            return sT2;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutST2(Guid id, ST2 sT2)
        {
            if (id != sT2.Id)
            {
                return BadRequest();
            }

            _context.Entry(sT2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ST2Exists(id))
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
        public async Task<ActionResult<ST2>> PostST2(ST2 sT2)
        {
            _context.St2s.Add(sT2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetST2", new { id = sT2.Id }, sT2);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ST2>> DeleteST2(Guid id)
        {
            var sT2 = await _context.St2s.FindAsync(id);
            if (sT2 == null)
            {
                return NotFound();
            }

            _context.St2s.Remove(sT2);
            await _context.SaveChangesAsync();

            return sT2;
        }

        private bool ST2Exists(Guid id)
        {
            return _context.St2s.Any(e => e.Id == id);
        }
    }
}
