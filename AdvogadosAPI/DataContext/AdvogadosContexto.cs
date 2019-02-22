using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvogadosAPI.Entidades;

namespace AdvogadosAPI.DataContext
{
    public class AdvogadosContexto : DbContext
    {
        public AdvogadosContexto(DbContextOptions<AdvogadosContexto> options)
           : base(options) { }
        public DbSet<AdvogadosAPI.Entidades.Cliente> Clientes { get; set; }
        public DbSet<AdvogadosAPI.Entidades.ProcessoCliente> ProcessoCliente { get; set; }



    }
}
