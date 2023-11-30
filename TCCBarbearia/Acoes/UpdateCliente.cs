using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class UpdateCliente
    {
        conn con = new conn();
        public void AlteraCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_Login SET nome_usu = @nome_usu, tel_usu = @tel_usu, email_usu = @email_usu, senha = @senha WHERE cod_usu = @cod_usu;", con.ConectarBD());
            {
                cmd.Parameters.Add("@cod_usu", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();

                con.DesconectarBD();
            }

        }
    }
}