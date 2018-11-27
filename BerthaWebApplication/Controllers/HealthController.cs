using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerthaWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BerthaWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly BerthaContext _context;

        public HealthController(BerthaContext context)
        {
            _context = context;
        }
        // GET: api/Health
        [HttpGet]
        public IEnumerable<Health> GetHealth()
        {
            return _context.HealthRecord;
        }

        // GET: api/Health/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.HealthRecord.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        // POST: api/Health
        [HttpPost]
        public async Task<IActionResult> PostHealth([FromBody] Health health)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HealthRecord.Add(health);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetHealth", new { id = health.HealthId }, health);
        }


        // PUT: api/Health/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthRecord([FromRoute] int id, [FromBody] Health hltdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hltdata.HealthId)
            {
                return BadRequest();
            }

            _context.Entry(hltdata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!HealthRecordExists(id))
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


        // DELETE: api/Health/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hltrecord = await _context.HealthRecord.FindAsync(id);
            if (hltrecord == null)
            {
                return NotFound();
            }

            _context.HealthRecord.Remove(hltrecord);
            await _context.SaveChangesAsync();

            return Ok(hltrecord);
        }

        private bool HealthRecordExists(int id)
        {
            return _context.HealthRecord.Any(e => e.HealthId == id);
        }
    }
}