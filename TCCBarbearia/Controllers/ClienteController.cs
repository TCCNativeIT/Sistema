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
        Usuario usu = new Usuario();
        LoginCliente login = new LoginCliente();
        CadastroCliente cadastro = new CadastroCliente();
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
                Session["usuarioLogado"].ToString();
                Session["senhaLogado"].ToString();

                if (usuario.tipo == "admin")
                {
                    Session["tipoLogadocli"] = usuario.tipo.ToString();
                    return RedirectToAction("Cliente", "Home");
                }
                else
                {
                    Session["tipoLogadoadmin"] = usuario.tipo.ToString();
                    return RedirectToAction("Admin", "Home");
                }

            }
            else
            {
                ViewBag.Login = "Usuário não encontrado!";
                return View();
            }

        }


        public ActionResult Cadastro(Usuario usuario)
        {
            cadastro.CadastroCli(usuario);
            return View();
        }
        
        //public ActionResult Cadastro(Usuario usuario)
        //{

        //    return View();
        //}

    
}
}