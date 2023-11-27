using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCBarbearia.Acoes;
using TCCBarbearia.Models;

namespace TCCBarbearia.Controllers
{
    public class AgendamentoController : Controller
    {
        // GET: Agendamento

        Agendamento Ag = new Agendamento();
        AgendamentoCliente AgC = new AgendamentoCliente();

        public ActionResult FormAgendamento()
        {
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
            Ag.cod_usu = Session["codLogado"].ToString();
            Ag.nome_usu = Session["nomeLogado"].ToString();
            Ag.email_usu = Session["emailLogado"].ToString();
            Ag.tel_usu = Session["telLogado"].ToString();
            Ag.email_usu = Session["emailLogado"].ToString();

            AgC.InsereAgenda(Ag);
            return RedirectToAction(nameof(Concluido));
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