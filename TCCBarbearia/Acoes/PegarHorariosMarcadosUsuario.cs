using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class PegarHorariosMarcadosUsuario
    {
        conn conn = new conn();
        public List<Agendamento> PegarTodosHorariosUsuarioLogado(int id)
        {
            List<Agendamento> horariosMarcadosList = new List<Agendamento>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Agendamento INNER JOIN tbl_Horas ON tbl_Agendamento.cod_Horas = tbl_Horas.cod_Horas where cod_usu = @codUsuario", conn.ConectarBD());
            cmd.Parameters.Add("@codUsuario", MySqlDbType.Int32).Value = id;

            MySqlDataReader leitor; 

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Agendamento horariosMarcados = new Agendamento();

                    horariosMarcados.nome_usu = Convert.ToString(leitor["nome_usu"]);
                    horariosMarcados.servico = Convert.ToString(leitor["servico"]);
                    horariosMarcados.data = Convert.ToDateTime(leitor["data_usu"]).ToString("dd'/'MM'/'yyyy");
                    horariosMarcados.preco = Convert.ToInt32(leitor["preco"]);
                    horariosMarcados.cod_agendamento = Convert.ToInt32(leitor["cod_agendamento"]);
                    horariosMarcados.email_usu = Convert.ToString(leitor["email_usu"]);
                    horariosMarcados.tel_usu = Convert.ToString(leitor["tel_usu"]);
                    horariosMarcados.horas = Convert.ToString(leitor["horarios"]);

                    horariosMarcadosList.Add(horariosMarcados);
                }
            }

            conn.DesconectarBD();

            return horariosMarcadosList;
        }
    }
}