using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.Entidades
{
    public class ProcessoCliente
    {
        [Key]
        public Guid processoClienteId { get; set; }

        public Guid clienteId { get; set; }

        [ForeignKey("clienteId")]
        public Cliente cliente { get; set; }

        public Guid processoId { get; set; }
        [ForeignKey("processoId")]
        public Processo processo { get; set; }

    }
}
