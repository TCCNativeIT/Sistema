using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Models
{
    public class Usuario
    {
        public  int cod_usu { get; set; }

        [StringLength(50, MinimumLength = 3,  ErrorMessage = "O nome deve conter no mínimo 3 e no máximo 50 caracteres!")]
        public string nome_usu { get; set; }
        public string email_usu { get; set; }

        [Required(ErrorMessage ="A senha é obrigatória!")]
        public string senha { get; set; }

        [Compare("senha", ErrorMessage = "As senhas são diferentes!")]
        public string confSenha { get; set; }
        public string tel_usu { get; set; }

    }
}