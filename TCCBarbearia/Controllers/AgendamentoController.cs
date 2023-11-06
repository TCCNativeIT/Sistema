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
            if (Session["usuarioLogado"] == null)
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
            AgC.InsereAgenda(Ag);
            return RedirectToAction(nameof(Concluido));
        }

        public ActionResult Concluido()
        {
            return View();
        }
    }
}