using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Models
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string tel { get; set; }
        public string tipo { get; set; }

    }
}