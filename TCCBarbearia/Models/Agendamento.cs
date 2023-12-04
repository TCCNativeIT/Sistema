using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI.WebControls;

namespace TCCBarbearia.Models
{
    public class Agendamento
    {
        public int cod_agendamento {  get; set; }
        public string servico { get; set; }
        public int preco { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? data { get; set; }
        public string horas { get; set; }
        public string nome_usu { get; set; }
        public string cod_usu { get; set; }
        public string email_usu { get; set; }
        public string tel_usu { get; set; }
        public string cod_horas  { get; set; }
    }
}