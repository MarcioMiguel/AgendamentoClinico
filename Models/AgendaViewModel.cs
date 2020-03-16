using Agendamento.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Agendamento.Utils.Dominios;

namespace Agendamento.Models
{
    public class AgendaViewModel
    {
        public AgendaViewModel()
        {
            this.Status = AgendamentoStatus.Agendado;
        }

        [Key]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Você deve selecionar o médico.")]
        [Display(Description = "Médico")]
        [ForeignKey("Medico")]
        public int MedicoCodigo { get; set; }

        [Required(ErrorMessage = "Você deve selecionar o paciente.")]
        [Display(Description = "Paciente")]
        [ForeignKey("Paciente")]
        public int PacienteCodigo { get; set; }

        [Required(ErrorMessage = "Insira a data do agendamento.")]
        [Display(Description = "Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Insira a hora do agendamento.")]
        [Display(Description = "Horas")]
        public DateTime Hora { get; set; }

        [Display(Description = "Status")]
        public AgendamentoStatus Status { get; set; }

        public Medico Medico { get; set; }
    }
}
