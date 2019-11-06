using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMR.Tracking.DataAccess;
using SMR.Tracking.Domain;
using SMR.Tracking.WebApi.ViewModels;

namespace SMR.Tracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiRailInspectionsController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public HiRailInspectionsController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiRailInspection>>> GetHiRailInspections()
        {
            return await _context.HiRailInspections.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HiRailInspection>> GetHiRailInspection(Guid id)
        {
            var hiRailInspection = await _context.HiRailInspections.FindAsync(id);

            if (hiRailInspection == null)
            {
                return NotFound();
            }

            return hiRailInspection;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiRailInspection(Guid id, HiRailInspection hiRailInspection)
        {
            if (id != hiRailInspection.Id)
            {
                return BadRequest();
            }

            
            _context.Entry(hiRailInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiRailInspectionExists(id))
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
        public async Task<ActionResult<HiRailInspection>> PostHiRailInspection(HiRailInspection hiRailInspection)
        {
            _context.HiRailInspections.Add(hiRailInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHiRailInspection", new { id = hiRailInspection.Id }, hiRailInspection);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HiRailInspection>> DeleteHiRailInspection(Guid id)
        {
            var hiRailInspection = await _context.HiRailInspections.FindAsync(id);
            if (hiRailInspection == null)
            {
                return NotFound();
            }

            _context.HiRailInspections.Remove(hiRailInspection);
            await _context.SaveChangesAsync();

            return hiRailInspection;
        }

        private bool HiRailInspectionExists(Guid id)
        {
            return _context.HiRailInspections.Any(e => e.Id == id);
        }
    }
}
