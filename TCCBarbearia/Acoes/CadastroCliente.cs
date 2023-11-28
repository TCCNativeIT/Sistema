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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Login(senha,nome_usu,tel_usu,email_usu)" +
                "VALUES(@senha,@nome_usu,@tel_usu,@email_usu)", conn.ConectarBD());

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usu.senha;
            cmd.Parameters.Add("@nome_usu", MySqlDbType.VarChar).Value = usu.nome_usu;
            cmd.Parameters.Add("@tel_usu", MySqlDbType.VarChar).Value = usu.tel_usu;
            cmd.Parameters.Add("@email_usu", MySqlDbType.VarChar).Value = usu.email_usu;

            cmd.ExecuteNonQuery();
            conn.DesconectarBD();

        }   

        public bool VerificaEmail(Usuario usu)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT email_usu FROM tbl_Login WHERE email_usu = @emailusu", conn.ConectarBD()))
            {
                cmd.Parameters.Add("@emailusu", MySqlDbType.VarChar).Value = usu.email_usu;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Se houver resultados, significa que o e-mail já existe
                    return reader.Read();
                }
            }
        }

    }
}