using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fanfic.Data;
using Fanfic.Models;

namespace Fanfic.Controllers
{
    [Produces("application/json")]
    [Route("api/Fanfics")]
    public class FanficsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FanficsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fanfics
        [HttpGet]
        public IEnumerable<Fanfic> GetFanfics()
        {
            return _context.Fanfics;
        }

        // GET: api/Fanfics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFanfic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fanfic = await _context.Fanfics.SingleOrDefaultAsync(m => m.Id == id);

            if (fanfic == null)
            {
                return NotFound();
            }

            return Ok(fanfic);
        }

        // PUT: api/Fanfics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFanfic([FromRoute] int id, [FromBody] Fanfic fanfic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fanfic.Id)
            {
                return BadRequest();
            }

            _context.Entry(fanfic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FanficExists(id))
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

        // POST: api/Fanfics
        [HttpPost]
        public async Task<IActionResult> PostFanfic([FromBody] Fanfic fanfic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fanfics.Add(fanfic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFanfic", new { id = fanfic.Id }, fanfic);
        }

        // DELETE: api/Fanfics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFanfic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fanfic = await _context.Fanfics.SingleOrDefaultAsync(m => m.Id == id);
            if (fanfic == null)
            {
                return NotFound();
            }

            _context.Fanfics.Remove(fanfic);
            await _context.SaveChangesAsync();

            return Ok(fanfic);
        }

        private bool FanficExists(int id)
        {
            return _context.Fanfics.Any(e => e.Id == id);
        }
    }
}