using AdvogadosAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.Repositório
{
    public interface IAdvgRepositorio
    {
        Task<IEnumerable<Cliente>> ObterClientesAsync();
        Task<Cliente> ObterClienteAsync(Guid id);
        void AdicionarCliente(Cliente cliente);
        Task<bool> SalvarAsync();
    }
}
