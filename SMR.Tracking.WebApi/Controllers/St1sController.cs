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
    public class St1sController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public St1sController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ST1>>> GetSt1s()
        {
            return await _context.St1s.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ST1>> GetST1(Guid id)
        {
            var sT1 = await _context.St1s.FindAsync(id);

            if (sT1 == null)
            {
                return NotFound();
            }

            return sT1;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutST1(Guid id, ST1 sT1)
        {
            if (id != sT1.Id)
            {
                return BadRequest();
            }

            _context.Entry(sT1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ST1Exists(id))
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
        public async Task<ActionResult<ST1>> PostST1(ST1 sT1)
        {
            _context.St1s.Add(sT1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetST1", new { id = sT1.Id }, sT1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ST1>> DeleteST1(Guid id)
        {
            var sT1 = await _context.St1s.FindAsync(id);
            if (sT1 == null)
            {
                return NotFound();
            }

            _context.St1s.Remove(sT1);
            await _context.SaveChangesAsync();

            return sT1;
        }

        private bool ST1Exists(Guid id)
        {
            return _context.St1s.Any(e => e.Id == id);
        }
    }
}
