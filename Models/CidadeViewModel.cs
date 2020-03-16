using Agendamento.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class CidadeViewModel
    {
        [Display(Description = "Código")]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Display(Description = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Display(Description = "UF")]
        public string UF { get; set; }

        public IEnumerable<SelectListItem> ListaEstado { get; set; }
    }
}
