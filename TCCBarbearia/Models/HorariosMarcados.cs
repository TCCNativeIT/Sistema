using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Models
{
    public class HorariosMarcados
    {
        public string nomeCliente { get; set; }
        public string servicoEscolhido { get; set; }

        public DateTime horarioEscolhido { get; set; }

        public int precoServico { get; set; }

        public int codigoAgendamento { get; set; }
    }
}