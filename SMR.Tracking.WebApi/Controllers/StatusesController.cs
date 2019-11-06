﻿using System;
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
    public class StatusesController : ControllerBase
    {
        private readonly CloudDbContext _context;

        public StatusesController(CloudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(Guid id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(Guid id, Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, status);
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(Guid id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return status;
        }

        private bool StatusExists(Guid id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
