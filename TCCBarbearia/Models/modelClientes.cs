using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TCCBarbearia.Models
{
    public class modelClientes
    {
        [Display(Name = "Código")]
        public int codCli { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório!")]
        [Display(Name = "Nome")]
        public string nomeCli { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório!")]
        [Display(Name = "Telefone")]
        public string telCli { get; set; }

        [Required(ErrorMessage = "O E_mail é obrigatório!")]
        [Display(Name = "E_mail")]
        public string emailCli { get; set; }

    }
}