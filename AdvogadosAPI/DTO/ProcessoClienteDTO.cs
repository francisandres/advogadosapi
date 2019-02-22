using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvogadosAPI.DTO
{
    public class ProcessoClienteDTO
    {
        
        public Guid processoClienteId { get; set; }

        public Guid clienteId { get; set; }
            
       
        public Guid processoId { get; set; }
        
        
    }
}
