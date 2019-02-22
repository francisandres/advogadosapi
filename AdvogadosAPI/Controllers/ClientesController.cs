using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvogadosAPI.DataContext;
using AdvogadosAPI.Entidades;
using AdvogadosAPI.Repositório;

namespace AdvogadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IAdvgRepositorio _repo;

        public ClientesController(IAdvgRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var clientes = await _repo.ObterClientesAsync();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "ObterClientePorId")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id)
        {
            var cliente = await _repo.ObterClienteAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
     

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> CriarCliente([FromBody] Cliente cliente)
        {
            _repo.AdicionarCliente(cliente);
            await _repo.SalvarAsync();  

            return CreatedAtRoute("ObterClientePorId", new { id = cliente.clienteId }, cliente);
           
        }

        // DELETE: api/Clientes/5
     

       
    }
}
