using Agendamento.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail.")]
        [Display(Description = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [Display(Description = "Senha")]
        public string Senha { get; set; }      
    }
}
