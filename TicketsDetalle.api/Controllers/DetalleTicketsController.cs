using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using TicketsDetalle.api.DAL;

namespace TicketsDetalle.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleTicketsController : ControllerBase
    {
        private readonly Contexto _context;

        public DetalleTicketsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/DetalleTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleTickets>>> GetDetalleTickets()
        {
            return await _context.DetalleTickets.ToListAsync();
        }

        // GET: api/DetalleTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleTickets>> GetDetalleTickets(int id)
        {
            var detalleTickets = await _context.DetalleTickets.FindAsync(id);

            if (detalleTickets == null)
            {
                return NotFound();
            }

            return detalleTickets;
        }

        // PUT: api/DetalleTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleTickets(int id, DetalleTickets detalleTickets)
        {
            if (id != detalleTickets.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(detalleTickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleTicketsExists(id))
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

        // POST: api/DetalleTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleTickets>> PostDetalleTickets(DetalleTickets detalleTickets)
        {
            _context.DetalleTickets.Add(detalleTickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleTickets", new { id = detalleTickets.DetalleId }, detalleTickets);
        }

        // DELETE: api/DetalleTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleTickets(int id)
        {
            var detalleTickets = await _context.DetalleTickets.FindAsync(id);
            if (detalleTickets == null)
            {
                return NotFound();
            }

            _context.DetalleTickets.Remove(detalleTickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleTicketsExists(int id)
        {
            return _context.DetalleTickets.Any(e => e.DetalleId == id);
        }
    }
}
