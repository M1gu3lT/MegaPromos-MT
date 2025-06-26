using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEGA_PROMOS.Api.Model;

namespace MEGA_PROMOS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscriptorDatasController : ControllerBase
    {
        private readonly SuscriptorDbContext _context;

        public SuscriptorDatasController(SuscriptorDbContext context)
        {
            _context = context;
        }

        // GET: api/SuscriptorDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuscriptorData>>> GetSuscriptor()
        {
            return await _context.Suscriptor.ToListAsync();
        }

        // GET: api/SuscriptorDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuscriptorData>> GetSuscriptorData(int id)
        {
            var suscriptorData = await _context.Suscriptor.FindAsync(id);

            if (suscriptorData == null)
            {
                return NotFound();
            }

            return suscriptorData;
        }

        // PUT: api/SuscriptorDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuscriptorData(int id, SuscriptorData suscriptorData)
        {
            if (id != suscriptorData.suscriptor_id)
            {
                return BadRequest();
            }

            _context.Entry(suscriptorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuscriptorDataExists(id))
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

        // POST: api/SuscriptorDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuscriptorData>> PostSuscriptorData(SuscriptorData suscriptorData)
        {
            _context.Suscriptor.Add(suscriptorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuscriptorData", new { id = suscriptorData.suscriptor_id }, suscriptorData);
        }

        // DELETE: api/SuscriptorDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuscriptorData(int id)
        {
            var suscriptorData = await _context.Suscriptor.FindAsync(id);
            if (suscriptorData == null)
            {
                return NotFound();
            }

            _context.Suscriptor.Remove(suscriptorData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuscriptorDataExists(int id)
        {
            return _context.Suscriptor.Any(e => e.suscriptor_id == id);
        }
    }
}
