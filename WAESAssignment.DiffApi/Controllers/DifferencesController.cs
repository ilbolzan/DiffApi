using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAESAssignment.Diff.Api.Model;
using WAESAssignment.Diff.Api.Models;

namespace WAESAssignment.Diff.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifferencesController : ControllerBase
    {
        private readonly WAESAssignmentDiffApiContext _context;

        public DifferencesController(WAESAssignmentDiffApiContext context)
        {
            _context = context;
        }

        // GET: api/Differences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Difference>>> GetDifference()
        {
            return await _context.Difference.ToListAsync();
        }

        // GET: api/Differences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Difference>> GetDifference(int id)
        {
            var difference = await _context.Difference.FindAsync(id);

            if (difference == null)
            {
                return NotFound();
            }

            return difference;
        }

        // PUT: api/Differences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifference(int id, Difference difference)
        {
            if (id != difference.Id)
            {
                return BadRequest();
            }

            _context.Entry(difference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifferenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Differences
        [HttpPost]
        public async Task<ActionResult<Difference>> PostDifference(Difference difference)
        {
            _context.Difference.Add(difference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDifference", new { id = difference.Id }, difference);
        }

        // DELETE: api/Differences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Difference>> DeleteDifference(int id)
        {
            var difference = await _context.Difference.FindAsync(id);
            if (difference == null)
            {
                return NotFound();
            }

            _context.Difference.Remove(difference);
            await _context.SaveChangesAsync();

            return difference;
        }

        private bool DifferenceExists(int id)
        {
            return _context.Difference.Any(e => e.Id == id);
        }
    }
}
