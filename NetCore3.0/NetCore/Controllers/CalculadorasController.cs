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
    public class CalculadorasController : ControllerBase
    {
        private readonly Context _context;

        public CalculadorasController(Context context)
        {
            _context = context;
        }

        // GET: api/Calculadoras
        [HttpGet]
        public string GetCalculadora(double d, double v)
        {
            return "Peso: " + new Calculadora().GetPeso(d, v) + " KG";
        }



        // GET: api/Calculadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculadora>> GetCalculadora(int id)
        {
            var calculadora = await _context.Calculadora.FindAsync(id);

            if (calculadora == null)
            {
                return NotFound();
            }

            return calculadora;
        }

        // PUT: api/Calculadoras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculadora(int id, Calculadora calculadora)
        {
            if (id != calculadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculadoraExists(id))
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

        // POST: api/Calculadoras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Calculadora>> PostCalculadora(Calculadora calculadora)
        {
            _context.Calculadora.Add(calculadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculadora", new { id = calculadora.Id }, calculadora);
        }

        // DELETE: api/Calculadoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calculadora>> DeleteCalculadora(int id)
        {
            var calculadora = await _context.Calculadora.FindAsync(id);
            if (calculadora == null)
            {
                return NotFound();
            }

            _context.Calculadora.Remove(calculadora);
            await _context.SaveChangesAsync();

            return calculadora;
        }

        private bool CalculadoraExists(int id)
        {
            return _context.Calculadora.Any(e => e.Id == id);
        }
    }
}
