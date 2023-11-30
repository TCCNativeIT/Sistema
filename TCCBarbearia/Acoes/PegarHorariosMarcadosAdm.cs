using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Acoes
{
    public class PegarHorariosMarcadosAdm
    {
        conn conn = new conn();
        public List<Agendamento> PegarTodosHorarios()
        {
            List<Agendamento> horariosMarcadosList = new List<Agendamento>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Agendamento", conn.ConectarBD());

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Agendamento horariosMarcados = new Agendamento();

                    horariosMarcados.cod_usu = Convert.ToString(leitor["cod_usu"]);
                    horariosMarcados.nome_usu = Convert.ToString(leitor["nome_usu"]);
                    horariosMarcados.servico = Convert.ToString(leitor["servico"]);
                    horariosMarcados.horas = Convert.ToString(leitor["horas"]);
                    horariosMarcados.data = Convert.ToDateTime(leitor["data_usu"]);
                    horariosMarcados.preco = Convert.ToInt32(leitor["preco"]);
                    horariosMarcados.cod_agendamento = Convert.ToInt32(leitor["cod_agendamento"]);
                    horariosMarcados.email_usu = Convert.ToString(leitor["email_usu"]);
                    horariosMarcados.tel_usu = Convert.ToString(leitor["tel_usu"]);

                    horariosMarcadosList.Add(horariosMarcados);
                }
            }

            conn.DesconectarBD();

            return horariosMarcadosList;
        }

        public List<Agendamento> PegarHorariosPorId(Int32 idAgendamento)
        {
            List<Agendamento> horariosMarcadosList = new List<Agendamento>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Agendamento where cod_agendamento = @idAgendamento ", conn.ConectarBD());
            cmd.Parameters.Add("@idAgendamento", MySqlDbType.Int32).Value = idAgendamento;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Agendamento horariosMarcados = new Agendamento();

                    horariosMarcados.nome_usu = Convert.ToString(leitor["nome_usu"]);
                    horariosMarcados.servico = Convert.ToString(leitor["servico"]);
                    horariosMarcados.data = Convert.ToDateTime(leitor["data_usu"]);
                    horariosMarcados.preco = Convert.ToInt32(leitor["preco"]);
                    horariosMarcados.cod_agendamento = Convert.ToInt32(leitor["cod_agendamento"]);
                    horariosMarcados.email_usu = Convert.ToString(leitor["email_usu"]);
                    horariosMarcados.tel_usu = Convert.ToString(leitor["tel_usu"]);
                    horariosMarcados.horas = Convert.ToString(leitor["horas"]);

                    horariosMarcadosList.Add(horariosMarcados);
                }
            }

            conn.DesconectarBD();

            return horariosMarcadosList;
        }

        public List<Usuario> ListarClientesCadastrados()
        {
            List<Usuario> usuariosCadastrados = new List<Usuario>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Login where nome_usu != @admin ", conn.ConectarBD());
            cmd.Parameters.Add("@admin", MySqlDbType.VarChar).Value = "Admin";
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.cod_usu = Convert.ToInt32(leitor["cod_usu"]);
                    usuario.nome_usu = Convert.ToString(leitor["nome_usu"]);
                    usuario.email_usu = Convert.ToString(leitor["email_usu"]);
                    usuario.tel_usu = Convert.ToString(leitor["tel_usu"]);

                    usuariosCadastrados.Add(usuario);

                }
            }

            conn.DesconectarBD();

            return usuariosCadastrados;
        }


    }
}