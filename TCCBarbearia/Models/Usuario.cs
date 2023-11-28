using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Models
{
    public class Usuario
    {
        public int cod_usu { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 e no máximo 50 caracteres!")]
        public string nome_usu { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
        public string email_usu { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 e 10 caracteres.")]
        public string senha { get; set; }

        [Compare("senha", ErrorMessage = "As senhas não coincidem!")]
        public string confSenha { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório!")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O formato do telefone é inválido.")]
        public string tel_usu { get; set; }
    }

}