using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEGA_PROMOS.Api.PromocionesModel;

namespace MEGA_PROMOS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesDatasController : ControllerBase
    {
        private readonly PromocionesDbContext _context;

        public PromocionesDatasController(PromocionesDbContext context)
        {
            _context = context;
        }

        // GET: api/PromocionesDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromocionesData>>> Getpromociones()
        {
            return await _context.promociones.ToListAsync();
        }

        // GET: api/PromocionesDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromocionesData>> GetPromocionesData(int id)
        {
            var promocionesData = await _context.promociones.FindAsync(id);

            if (promocionesData == null)
            {
                return NotFound();
            }

            return promocionesData;
        }

        // PUT: api/PromocionesDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromocionesData(int id, PromocionesData promocionesData)
        {
            if (id != promocionesData.promocion_id)
            {
                return BadRequest();
            }

            _context.Entry(promocionesData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionesDataExists(id))
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

        // POST: api/PromocionesDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PromocionesData>> PostPromocionesData(PromocionesData promocionesData)
        {
            _context.promociones.Add(promocionesData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromocionesData", new { id = promocionesData.promocion_id }, promocionesData);
        }

        // DELETE: api/PromocionesDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocionesData(int id)
        {
            var promocionesData = await _context.promociones.FindAsync(id);
            if (promocionesData == null)
            {
                return NotFound();
            }

            _context.promociones.Remove(promocionesData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocionesDataExists(int id)
        {
            return _context.promociones.Any(e => e.promocion_id == id);
        }
    }
}
