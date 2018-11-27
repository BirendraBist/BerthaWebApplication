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
    public class EnvironmentController : ControllerBase
    {
        private readonly BerthaContext _context;

        public EnvironmentController(BerthaContext context)
        {
            _context = context;
        }
        // GET: api/Environment 
        [HttpGet]
        public IEnumerable<Models.Environment> GetEnvironmentData()
        {
            return _context.EnvironmentRecord;
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnvironmentRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _context.EnvironmentRecord.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }


        // POST: api/Environment
        [HttpPost]
        public async Task<IActionResult> PostRecord([FromBody] Models.Environment envdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EnvironmentRecord.Add(envdata);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetRecord", new { id = envdata.EvnironmentId }, envdata);
        }


        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentRecord([FromRoute] int id, [FromBody] Models.Environment envdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != envdata.EvnironmentId)
            {
                return BadRequest();
            }

            _context.Entry(envdata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!EnvironmentRecordExists(id))
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
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvironmentData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var envrecord = await _context.EnvironmentRecord.FindAsync(id);
            if (envrecord == null)
            {
                return NotFound();
            }

            _context.EnvironmentRecord.Remove(envrecord);
            await _context.SaveChangesAsync();

            return Ok(envrecord);
        }

        private bool EnvironmentRecordExists(int id)
        {
            return _context.EnvironmentRecord.Any(e => e.EvnironmentId == id);
        }
    }
}