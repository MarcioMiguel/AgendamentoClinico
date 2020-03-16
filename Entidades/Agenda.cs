using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Agendamento.Utils.Dominios;

namespace Agendamento.Entidades
{
    public class Agenda
    {
        [Key]
        public int? Codigo { get; set; }
        public int MedicoCodigo { get; set; }
        public int PacienteCodigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public AgendamentoStatus Status { get; set; }
        public Medico Medico { get; set; }

    }
}
