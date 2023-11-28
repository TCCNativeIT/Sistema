using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TCCBarbearia.Acoes;
using TCCBarbearia.Db;
using TCCBarbearia.Models;

namespace TCCBarbearia.Controllers
{
    public class ClienteController : Controller
    {

        conn conn = new conn();
        LoginCliente login = new LoginCliente();
        CadastroCliente cadastro = new CadastroCliente();
        Usuario usu = new Usuario();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Usuario usuario)
        {
            login.TestarCliente(usuario);



            if (usuario.nome_usu == "Admin" && usuario.email_usu == "admin@gmail.com" && usuario.senha == "12345")
            {
                Session["emailLogado"] = usuario.email_usu.ToString();
                Session["senhaLogado"] = usuario.senha.ToString();
                Session["nomeLogado"] = usuario.nome_usu.ToString();
                Session["senhaLogado"] = usuario.senha.ToString();
                Session["codLogado"] = usuario.cod_usu;
                Session["telLogado"] = usuario.tel_usu.ToString();

                return RedirectToAction("AdminHome", "Admin");
            }
            else if (usuario.email_usu != null && usuario.senha != null)
            {
                Session["emailLogado"] = usuario.email_usu.ToString();
                Session["senhaLogado"] = usuario.senha.ToString();
                Session["nomeLogado"] = usuario.nome_usu.ToString();
                Session["senhaLogado"] = usuario.senha.ToString();
                Session["codLogado"] = usuario.cod_usu.ToString();
                Session["telLogado"] = usuario.tel_usu.ToString();


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Login = "Usuário não encontrado!";
                return View();
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastro(Usuario usuario)
        {
            if (!cadastro.VerificaEmail(usuario))
            {
                cadastro.CadastroCli(usuario);
                ViewBag.Message = "Cadastro feito com sucesso!";
            }
            ModelState.AddModelError("email_usu", "Este e-mail já está em uso.");
            return View();
        }

        public ActionResult Logout()
        {
            Session["emailLogado"] = null;
            Session["senhaLogado"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Conta(int idLogado)
        {

            return View();
        }




        public ActionResult AgendamentosConta(int id)
        {
            PegarHorariosMarcadosUsuario horarios = new PegarHorariosMarcadosUsuario();
            List<Agendamento> horariosMarcadosConta = horarios.PegarTodosHorariosUsuarioLogado(id);
            ViewBag.HorariosMarcadosConta = horariosMarcadosConta;
            return View();
        }


    }
}