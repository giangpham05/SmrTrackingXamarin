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
    public class HiRailAssetTypesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public HiRailAssetTypesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiRailAssetType>>> GetHiRailAssetTypes()
        {
            return await _context.HiRailAssetTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HiRailAssetType>> GetHiRailAssetType(Guid id)
        {
            var hiRailAssetType = await _context.HiRailAssetTypes.FindAsync(id);

            if (hiRailAssetType == null)
            {
                return NotFound();
            }

            return hiRailAssetType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiRailAssetType(Guid id, HiRailAssetType hiRailAssetType)
        {
            if (id != hiRailAssetType.Id)
            {
                return BadRequest();
            }

            _context.Entry(hiRailAssetType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiRailAssetTypeExists(id))
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
        public async Task<ActionResult<HiRailAssetType>> PostHiRailAssetType(HiRailAssetType hiRailAssetType)
        {
            _context.HiRailAssetTypes.Add(hiRailAssetType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHiRailAssetType", new { id = hiRailAssetType.Id }, hiRailAssetType);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HiRailAssetType>> DeleteHiRailAssetType(Guid id)
        {
            var hiRailAssetType = await _context.HiRailAssetTypes.FindAsync(id);
            if (hiRailAssetType == null)
            {
                return NotFound();
            }

            _context.HiRailAssetTypes.Remove(hiRailAssetType);
            await _context.SaveChangesAsync();

            return hiRailAssetType;
        }

        private bool HiRailAssetTypeExists(Guid id)
        {
            return _context.HiRailAssetTypes.Any(e => e.Id == id);
        }
    }
}
