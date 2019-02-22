using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.Entidades
{
    public class Processo
    {
        [Key]
        public Guid MyProperty { get; set; }
        public ICollection<ProcessoCliente>  processoCliente { get; set; }
    }
}
