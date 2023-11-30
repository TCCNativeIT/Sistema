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
        public void AlteraCliente(Usuario usu)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_Login SET nome_usu = @nome_usu, tel_usu = @tel_usu, email_usu = @email_usu, senha = @senha WHERE cod_usu = @cod_usu;", con.ConectarBD());
            {

                cmd.Parameters.AddWithValue("@nome_usu", usu.nome_usu);
                cmd.Parameters.AddWithValue("@tel_usu", usu.tel_usu);
                cmd.Parameters.AddWithValue("@email_usu", usu.email_usu);
                cmd.Parameters.AddWithValue("@senha", usu.senha);

                cmd.ExecuteNonQuery();

                con.DesconectarBD();
            }

        }
    }
}