using MySql.Data.MySqlClient;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class AgendamentoCliente
    {
        conn con = new conn();

        public void InsereAgenda(Agendamento Ag)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Tbl_Agendamento(servico, preco, horario) " +
                "VALUES(@servico, @preco, @horario)", con.ConectarBD());

            cmd.Parameters.Add("@servico", MySqlDbType.VarChar).Value = Ag.servico;
            cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = Ag.preco;
            cmd.Parameters.Add("@horario", MySqlDbType.DateTime).Value = Ag.horario;

            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }
    }
}