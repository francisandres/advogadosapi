using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvogadosAPI.DataContext;
using AdvogadosAPI.Entidades;

namespace AdvogadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoClientesController : ControllerBase
    {
        private readonly AdvogadosContexto _context;

        public ProcessoClientesController(AdvogadosContexto context)
        {
            _context = context;
        }

        // GET: api/ProcessoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoCliente>>> GetProcessoCliente()
        {
            return await _context.ProcessoCliente.ToListAsync();
        }

        // GET: api/ProcessoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoCliente>> GetProcessoCliente(Guid id)
        {
            var processoCliente = await _context.ProcessoCliente.FindAsync(id);

            if (processoCliente == null)
            {
                return NotFound();
            }

            return processoCliente;
        }

        // PUT: api/ProcessoClientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoCliente(Guid id, ProcessoCliente processoCliente)
        {
            if (id != processoCliente.processoClienteId)
            {
                return BadRequest();
            }

            _context.Entry(processoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoClienteExists(id))
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

        // POST: api/ProcessoClientes
        [HttpPost]
        public async Task<ActionResult<ProcessoCliente>> PostProcessoCliente(ProcessoCliente processoCliente)
        {
            _context.ProcessoCliente.Add(processoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessoCliente", new { id = processoCliente.processoClienteId }, processoCliente);
        }

        // DELETE: api/ProcessoClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProcessoCliente>> DeleteProcessoCliente(Guid id)
        {
            var processoCliente = await _context.ProcessoCliente.FindAsync(id);
            if (processoCliente == null)
            {
                return NotFound();
            }

            _context.ProcessoCliente.Remove(processoCliente);
            await _context.SaveChangesAsync();

            return processoCliente;
        }

        private bool ProcessoClienteExists(Guid id)
        {
            return _context.ProcessoCliente.Any(e => e.processoClienteId == id);
        }
    }
}
