using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class CadastroCliente
    {
        conn conn = new conn();

        public void CadastroCli(Usuario usu)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Cliente() values(@usuario,@senha )", conn.ConectarBD());



            conn.DesconectarBD();

        }

    }
}