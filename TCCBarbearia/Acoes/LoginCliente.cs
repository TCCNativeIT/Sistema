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
        public void TestarCliente(Usuario cliente)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_Login where usuario = @usuario and senha = @senha", conn.ConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cliente.username;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cliente.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    cliente.username = Convert.ToString(leitor["usuario"]);
                    cliente.senha = Convert.ToString(leitor["senha"]);
                }
            }
            else
            {
                cliente.username = null;
                cliente.senha = null;
                cliente.tipo = null;
            }

            conn.DesconectarBD();

        }
    }
}