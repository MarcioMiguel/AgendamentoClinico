using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Entidades
{
    public class Estado
    {
        [Key]
        public string Sigla { get; set; }
    }
}
