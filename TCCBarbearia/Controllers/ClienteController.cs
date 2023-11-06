using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCBarbearia.Acoes;
using TCCBarbearia.Models;

namespace TCCBarbearia.Controllers
{
    public class ClienteController : Controller
    {
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
            if (usuario.username != null && usuario.senha != null)
            {
                Session["usuarioLogado"] = usuario.username.ToString();
                Session["senhaLogado"] = usuario.senha.ToString();

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
            cadastro.CadastroCli(usuario);
            ViewBag.Message = "Cadastro feito com sucesso!";
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            return RedirectToAction("Index", "Home");
        }
        
        //public ActionResult Cadastro(Usuario usuario)
        //{

        //    return View();
        //}

    
}
}