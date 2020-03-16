using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class MedicoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Número é obrigatório.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Escolha a cidade.")]
        [Display(Name = "Cidade")]
        public int CidadeCodigo { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Qual a especialidade?")]
        [Display(Name = "Especialidade")]
        public string Especialidade { get; set; }

        public IEnumerable<SelectListItem> ListaCidade { get; set; }

    }
}
