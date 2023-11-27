using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCBarbearia.Models;

namespace TCCBarbearia.Db
{
    public class acoesLogin
    {
        conn con = new conn();

        public void TestarUsuario(modelLogin mL)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Login where usuario = @usuario and senha = @senha", con.ConectarBD());


            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = mL.usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = mL.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    mL.usuario = Convert.ToString(leitor["usuario"]);
                    mL.usuario = Convert.ToString(leitor["senha"]);
                    mL.usuario = Convert.ToString(leitor["tipo"]);
                }
            }
            else
            {
                mL.usuario = null;
                mL.senha = null;
                mL.tipo = null;
            }
            con.DesconectarBD();
        }
    }
}