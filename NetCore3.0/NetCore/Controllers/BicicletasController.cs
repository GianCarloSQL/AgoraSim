using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Models;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletasController : ControllerBase
    {
        private readonly Context _context;

        public BicicletasController(Context context)
        {
            _context = context;
        }

        // GET: api/Bicicletas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicicleta>>> GetBicicletas()
        {
            return await _context.Bicicletas.ToListAsync();
        }
        [HttpGet]
        [Route("api/peso")]
        public async Task<ActionResult<string>> GetCalculadora(double d, double v)
        {
            return "Peso: " + new Calculadora().GetPeso(d, v);
        }

        // GET: api/Bicicletas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicicleta>> GetBicicleta(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);

            if (bicicleta == null)
            {
                return NotFound();
            }

            return bicicleta;
        }

        // PUT: api/Bicicletas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicicleta(int id, Bicicleta bicicleta)
        {
            if (id != bicicleta.Id)
            {
                return BadRequest();
            }

            _context.Entry(bicicleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicicletaExists(id))
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

        // POST: api/Bicicletas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bicicleta>> PostBicicleta(Bicicleta bicicleta)
        {
            _context.Bicicletas.Add(bicicleta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBicicleta", new { id = bicicleta.Id }, bicicleta);
        }

        // DELETE: api/Bicicletas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicicleta>> DeleteBicicleta(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            _context.Bicicletas.Remove(bicicleta);
            await _context.SaveChangesAsync();

            return bicicleta;
        }

        private bool BicicletaExists(int id)
        {
            return _context.Bicicletas.Any(e => e.Id == id);
        }
    }
}
