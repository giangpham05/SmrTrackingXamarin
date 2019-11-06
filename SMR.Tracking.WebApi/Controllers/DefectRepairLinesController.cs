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
    public class DefectRepairLinesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public DefectRepairLinesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DefectRepairLine>>> GetRepairLines()
        {
            return await _context.RepairLines.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DefectRepairLine>> GetDefectRepairLine(Guid id)
        {
            var defectRepairLine = await _context.RepairLines.FindAsync(id);

            if (defectRepairLine == null)
            {
                return NotFound();
            }

            return defectRepairLine;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefectRepairLine(Guid id, DefectRepairLine defectRepairLine)
        {
            if (id != defectRepairLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(defectRepairLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectRepairLineExists(id))
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
        public async Task<ActionResult<DefectRepairLine>> PostDefectRepairLine(DefectRepairLine defectRepairLine)
        {
            _context.RepairLines.Add(defectRepairLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefectRepairLine", new { id = defectRepairLine.Id }, defectRepairLine);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DefectRepairLine>> DeleteDefectRepairLine(Guid id)
        {
            var defectRepairLine = await _context.RepairLines.FindAsync(id);
            if (defectRepairLine == null)
            {
                return NotFound();
            }

            _context.RepairLines.Remove(defectRepairLine);
            await _context.SaveChangesAsync();

            return defectRepairLine;
        }

        private bool DefectRepairLineExists(Guid id)
        {
            return _context.RepairLines.Any(e => e.Id == id);
        }
    }
}
