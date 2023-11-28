using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class Carrinho
    {
        conn conn = new conn();

        public List<Agendamento> CarrinhoPorEmail(Usuario email)
        {
            List<Agendamento> AgendamentoCarrinhoList = new List<Agendamento>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Agendamento WHERE email_usu = @email_usu", conn.ConectarBD());
            cmd.Parameters.Add("@email_usu", MySqlDbType.VarChar).Value = email;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Agendamento AgC = new Agendamento();
                    AgC.servico = Convert.ToString(leitor["servico"]);
                    AgC.preco = Convert.ToInt32(leitor["preco"]);
                    AgC.data = Convert.ToDateTime(leitor["data_usu"]);
                    AgC.cod_agendamento = Convert.ToInt32(leitor["cod_Agendamento"]);


                    AgendamentoCarrinhoList.Add(AgC);
                }
            }
            conn.DesconectarBD();
            return AgendamentoCarrinhoList;
        }
    }
}
