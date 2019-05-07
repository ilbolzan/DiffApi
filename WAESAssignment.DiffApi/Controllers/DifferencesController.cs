using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAESAssignment.Diff.Api.Interfaces.Repository;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Models;

namespace WAESAssignment.Diff.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private readonly IDifferenceLeftRepository _differenceLeftRepository;
        private readonly IDifferenceRightRepository _differenceRightRepository;

        public DiffController(
            IDifferenceLeftRepository differenceLeftRepository, 
            IDifferenceRightRepository differenceRightRepository)
        {
            _differenceLeftRepository = differenceLeftRepository;
            _differenceRightRepository = differenceRightRepository;
        }

        //// GET: api/Differences
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Difference>>> GetDifference()
        //{
        //    return await _context.Difference.ToListAsync();
        //}

        //// GET: api/Differences/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Difference>> GetDifference(int id)
        //{
        //    var difference = await _context.Difference.FindAsync(id);

        //    if (difference == null)
        //    {
        //        return NotFound();
        //    }

        //    return difference;
        //}

        //// PUT: api/Differences/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDifference(int id, Difference difference)
        //{
        //    if (id != difference.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(difference).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DifferenceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // GET: api/Differences/5
        [HttpGet("{id}/left")]
        public async Task<ActionResult<DifferenceLeft>> GetDifferenceLeft(int id)
        {
            var difference = await _differenceLeftRepository.GetById(id);

            if (difference == null)
            {
                return NotFound();
            }

            return difference;
        }

        [HttpPost("{id}/left")]
        public ActionResult<Difference> PostLeft(int id, string base64Left)
        {
            var differenceLeft = new DifferenceLeft(id, base64Left);

            _differenceLeftRepository.Add(differenceLeft);

            return CreatedAtAction("GetDifferenceLeft", new { id = differenceLeft.Id }, differenceLeft);
        }

        [HttpPost("{id}/right")]
        public ActionResult<Difference> PostRight(DifferenceRight differenceRight)
        {
            _differenceRightRepository.Add(differenceRight);

            return CreatedAtAction("GetDifference", new { id = differenceRight.Id }, differenceRight);
        }
    }
}
