using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Entidades
{
    public class Cidade
    {
        [Key]        
        public int? Codigo { get; set; }        
        public string Nome { get; set; }
        public string UF { get; set; }     
        
    }
}
