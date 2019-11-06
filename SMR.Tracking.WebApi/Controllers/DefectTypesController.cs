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
    public class DefectTypesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public DefectTypesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DefectType>>> GetDefectTypes()
        {
            return await _context.DefectTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DefectType>> GetDefectType(Guid id)
        {
            var defectType = await _context.DefectTypes.FindAsync(id);

            if (defectType == null)
            {
                return NotFound();
            }

            return defectType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefectType(Guid id, DefectType defectType)
        {
            if (id != defectType.Id)
            {
                return BadRequest();
            }

            _context.Entry(defectType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectTypeExists(id))
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
        public async Task<ActionResult<DefectType>> PostDefectType(DefectType defectType)
        {
            _context.DefectTypes.Add(defectType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefectType", new { id = defectType.Id }, defectType);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DefectType>> DeleteDefectType(Guid id)
        {
            var defectType = await _context.DefectTypes.FindAsync(id);
            if (defectType == null)
            {
                return NotFound();
            }

            _context.DefectTypes.Remove(defectType);
            await _context.SaveChangesAsync();

            return defectType;
        }

        private bool DefectTypeExists(Guid id)
        {
            return _context.DefectTypes.Any(e => e.Id == id);
        }
    }
}
