using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.Entidades
{
    public class Cliente
    {
        [Key]
        public Guid? clienteId { get; set; }
        public string primeiroNome { get; set; }
        public string ultimoNome { get; set; }
        public DateTime? dataDeNascimento { get; set; }
        public string numeroDeBilhete { get; set; }
        public string email { get; set; }
        public decimal saldo { get; set; }
        public ICollection<ProcessoCliente> processoCliente { get; set; }

    }
}
