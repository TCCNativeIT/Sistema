using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TCCBarbearia.Models;

namespace TCCBarbearia.Db
{
    public class acoesCliente
    {
        conn con = new conn();

        public void inserirCliente(modelClientes mC)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Cliente(nomeCli, telCli, emailCli)" +
                "values(@nome_cli, @tel_cli, @email_cli)", con.ConectarBD());

            cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = mC.nomeCli;
            cmd.Parameters.Add("@telCli", MySqlDbType.VarChar).Value = mC.telCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = mC.emailCli;

            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public List<modelClientes> buscarCli()
        {
            List<modelClientes> clList = new List<modelClientes>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Cliente", con.ConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.DesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                clList.Add(
                    new modelClientes
                    {
                        codCli = Convert.ToInt32(dr["codCli"]),
                        nomeCli = Convert.ToString(dr["nomeCli"]),
                        telCli = Convert.ToString(dr["telCli"]),
                        emailCli = Convert.ToString(dr["emailCli"])
                    });
            }
            return clList;
        }

        public void atualizarCliente(modelClientes mC)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE SET nomeCli=@nome_cli, telCli=@tel_cli," +
            "emailCli=@emailCli WHERE codCli=@cod_cli", con.ConectarBD());

            cmd.Parameters.Add("@codCli", MySqlDbType.VarChar).Value = mC.codCli;
            cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = mC.nomeCli;
            cmd.Parameters.Add("@telCli", MySqlDbType.VarChar).Value = mC.telCli;
            cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = mC.emailCli;

            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }
        public void deleteCli(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_Cliente WHERE codCli=@cod_cli", con.ConectarBD());
            cmd.Parameters.AddWithValue("@codCli", cod);
            int i = cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }
    }
}