using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class DeleteHorario
    {
        conn con = new conn();
        public void Deletar(int Id)
        {
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Tbl_Agendamento WHERE cod_agendamento = @idAgendamento", con.ConectarBD()))
            {
                cmd.Parameters.Add("@idAgendamento", MySqlDbType.Int32).Value = Id;
                cmd.ExecuteNonQuery();
            }
            con.DesconectarBD();
        }

    }
}