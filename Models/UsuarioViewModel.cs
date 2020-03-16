using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Agendamento.Utils.Dominios;

namespace Agendamento.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int? Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }        

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [Display(Name = "Senha")]       
        public string Senha { get; set; }
        
    }
}
