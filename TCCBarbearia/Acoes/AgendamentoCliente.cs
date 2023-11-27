using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class AgendamentoCliente
    {
        conn con = new conn();

        public void InsereAgenda(Agendamento Ag)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Tbl_Agendamento(servico,preco,data,nome_usu,cod_usu,email_usu,tel_usu, horas) " +
                "VALUES(@servico, @preco,@data, @nome_usu, @cod_usu, @email_usu, @tel_usu, @horas)", con.ConectarBD());

            cmd.Parameters.Add("@servico", MySqlDbType.VarChar).Value = Ag.servico;
            cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = Ag.preco;
            cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = Ag.data;

            cmd.Parameters.Add("@nome_usu", MySqlDbType.VarChar).Value = Ag.nome_usu;
            cmd.Parameters.Add("@cod_usu", MySqlDbType.Int32).Value = Ag.cod_usu;
            cmd.Parameters.Add("@email_usu", MySqlDbType.VarChar).Value = Ag.email_usu;
            cmd.Parameters.Add("@tel_usu", MySqlDbType.VarChar).Value = Ag.tel_usu;
            cmd.Parameters.Add("@horas", MySqlDbType.VarChar).Value = Ag.horas;

            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }
    }
}