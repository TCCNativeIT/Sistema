using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Services.Description;
using TCCBarbearia.Acoes;
using TCCBarbearia.Models;

namespace TCCBarbearia.Controllers
{
    public class AgendamentoController : Controller
    {
        // GET: Agendamento

            Agendamento Ag = new Agendamento();
        AgendamentoCliente AgC = new AgendamentoCliente();

        public void CarregarHoras()
        {
            List<SelectListItem> Horas = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=BdBarbearia;user id=root;password=14154678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Tbl_Horas", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Horas.Add(new SelectListItem
                    {
                        Text = rdr[0].ToString(),
                        Value = rdr[1].ToString()
                    });
                }
                con.Close();

            }
            ViewBag.Horas = new SelectList(Horas, "Text", "Value");
        }

        public ActionResult FormAgendamento()
        {
            CarregarHoras();

            if (Session["emailLogado"] == null)
            {
                return RedirectToAction("Login", "Cliente", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult FormAgendamento(Agendamento Ag)
        {
            CarregarHoras();
            Ag.cod_usu = Session["codLogado"].ToString();
            Ag.nome_usu = Session["nomeLogado"].ToString();
            Ag.email_usu = Session["emailLogado"].ToString();
            Ag.tel_usu = Session["telLogado"].ToString();
            Ag.email_usu = Session["emailLogado"].ToString();
            Ag.cod_horas = Request["Horas"];
            
            AgC.InsereAgenda(Ag);
            
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetHorariosDropDown()
        {
            CarregarHoras();
            return View();
        }


        private SelectList GetItensDropdown()
        {
            return new SelectList(new[]
            {
            new SelectListItem { Value = "Opcao1", Text = "Opção 1" },
            new SelectListItem { Value = "Opcao2", Text = "Opção 2" },
            new SelectListItem { Value = "Opcao3", Text = "Opção 3" }
        }, "Value", "Text");
        }

        public ActionResult Concluido()
        {
            return View();
        }
        public ActionResult Formes()
        {
            return View();
        }
    }
}