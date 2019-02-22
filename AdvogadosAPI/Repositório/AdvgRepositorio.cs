using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvogadosAPI.DataContext;
using AdvogadosAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdvogadosAPI.Repositório
{
    public class AdvgRepositorio : IAdvgRepositorio
    {
        private AdvogadosContexto _ctx;

        public AdvgRepositorio(AdvogadosContexto ctx)
        {
            _ctx = ctx ?? throw new ArgumentException(nameof(ctx));

        }

        public void  AdicionarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            _ctx.AddAsync(cliente);
        }

        public async Task<Cliente> ObterClienteAsync(Guid id)
        {
            return await _ctx.Clientes.FirstOrDefaultAsync( c => c.clienteId == id);
        }

        public async Task<IEnumerable<Cliente>> ObterClientesAsync()
        {
            return await _ctx.Clientes.ToListAsync();
        }

        public async Task<bool> SalvarAsync()
        {
            return (await _ctx.SaveChangesAsync() > 0);
        }

        private bool ClienteExists(Guid id)
        {
            return _ctx.Clientes.Any(e => e.clienteId == id);
        }

        
}
}
