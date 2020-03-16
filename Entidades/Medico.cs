using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Entidades
{
    public class Medico
    {
        [Key]
        public int? Codigo { get; set; }        
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        public int CidadeCodigo { get; set; }
        public string Email { get; set; }
        public string Especialidade { get; set; }

        public ICollection<Agenda> Agendamentos { get; set; }
    }
}
