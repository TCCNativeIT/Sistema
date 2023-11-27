using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TCCBarbearia.Acoes;
using TCCBarbearia.Models;

namespace TCCBarbearia.Controllers
{
    public class AdminController : Controller
    {
        HorariosMarcados horario = new HorariosMarcados();
        // GET: Admin
            PegarHorariosMarcadosAdm pegarHorarios = new PegarHorariosMarcadosAdm();
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            List<Agendamento> horariosList = pegarHorarios.PegarTodosHorarios();
            ViewBag.HorariosList = horariosList;
            return View();
        }

        public ActionResult AdminDetalhesCorte(Int32 idAgendamento)
        {

            List<Agendamento> horarioPorID = pegarHorarios.PegarHorariosPorId(idAgendamento);
            ViewBag.HorarioMarcado = horarioPorID;
            return View(idAgendamento);
        }

        public ActionResult AdminClientesCadastrados()
        {
            List<Usuario> usuariosCadastrados = pegarHorarios.ListarClientesCadastrados();
            ViewBag.ListaClientesCadastrados = usuariosCadastrados;
            return View();
        }

    }
}