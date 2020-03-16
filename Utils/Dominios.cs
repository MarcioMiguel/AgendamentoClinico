using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Utils
{
    public class Dominios
    {
        public enum AgendamentoStatus
        {
            [Description("0 - AGENDADO")]
            Agendado,

            [Description("1 - REMARCADO")]
            Remarcado,

            [Description("2 - CANCELADO")]
            Cancelado
        }

        public enum UsuarioTipo
        {
            [Description("0 - Atendente")]
            Atendente,

            [Description("1 - Médico")]
            Médico            
        }
    }
}
