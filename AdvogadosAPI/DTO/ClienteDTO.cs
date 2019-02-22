using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.DTO
{
    public class ClienteDTO
    {
        public Guid clienteId { get; set; }
        public string primeiroNome { get; set; }
        public string ultimoNome { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string numeroDeBilhete { get; set; }
        public string email { get; set; }
        public decimal saldo { get; set; }
        
    }
}
