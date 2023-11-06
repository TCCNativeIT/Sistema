using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Models
{
    public class Agendamento
    {
        public string servico { get; set; }

        public int preco { get; set; }

        public DateTime horario { get; set; }


    }
}