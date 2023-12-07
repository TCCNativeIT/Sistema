using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Reflection;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class AgendamentoCliente
    {
        conn con = new conn();

        public void InsereAgenda(Agendamento Ag)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Tbl_Agendamento(servico,preco,data_usu,nome_usu,cod_usu,email_usu,tel_usu,cod_horas)" +
                "VALUES(@servico, @preco,@data_usu, @nome_usu, @cod_usu, @email_usu, @tel_usu, @cod_horas)", con.ConectarBD());

            cmd.Parameters.Add("@servico", MySqlDbType.VarChar).Value = Ag.servico;

            if (Ag.servico == "Corte Cabelo")
            {
                Ag.preco = 35;
            }
            else if (Ag.servico == "Barba")
            {
                Ag.preco = 30;
            }
            else if (Ag.servico == "Corte e Barba")
            {
                Ag.preco = 65;
            }

            cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = Ag.preco;

            

                
            cmd.Parameters.Add("@data_usu", MySqlDbType.VarChar).Value = Ag.data;
            cmd.Parameters.Add("@nome_usu", MySqlDbType.VarChar).Value = Ag.nome_usu;
            cmd.Parameters.Add("@cod_usu", MySqlDbType.Int32).Value = Ag.cod_usu;
            cmd.Parameters.Add("@email_usu", MySqlDbType.VarChar).Value = Ag.email_usu;
            cmd.Parameters.Add("@tel_usu", MySqlDbType.VarChar).Value = Ag.tel_usu;
            cmd.Parameters.Add("@cod_horas", MySqlDbType.VarChar).Value = Ag.cod_horas;

            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }
    }
}