using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class LoginCliente
    {
        conn conn = new conn();
        public void TestarCliente(Usuario usuario)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_Login where email_usu = @email_usu and senha = @senha", conn.ConectarBD());

            cmd.Parameters.Add("@email_usu", MySqlDbType.VarChar).Value = usuario.email_usu;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    usuario.email_usu = Convert.ToString(leitor["email_usu"]);
                    usuario.senha = Convert.ToString(leitor["senha"]);
                    usuario.nome_usu = Convert.ToString(leitor["nome_usu"]);
                    usuario.tel_usu = Convert.ToString(leitor["tel_usu"]);
                    usuario.cod_usu = Convert.ToInt32(leitor["cod_usu"]);
                }
            }
            else
            {
                usuario.email_usu = null;
                usuario.senha = null;
            }

            conn.DesconectarBD();

        }
    }
}