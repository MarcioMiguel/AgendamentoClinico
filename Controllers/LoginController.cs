using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.DAL;
using Agendamento.Entidades;
using Agendamento.Helpers;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        protected Contexto myContexto;

        public LoginController(Contexto contexto)
        {
            myContexto = contexto;
        }


        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            ViewData["ErrorLogin"] = string.Empty;
            if (ModelState.IsValid)
            {

                string senha = Criptografia.GetMd5Hash(login.Senha);
                Usuario usuario = myContexto.Usuario.Where(l => l.Email == login.Email && l.Senha == senha).FirstOrDefault();

                if (usuario == null)
                {
                    ViewData["ErrorLogin"] = "Login não encontrado no sistema.";
                    return View(login);
                }

                return RedirectToAction("Index","Home");

            }
            else
            {
                return View(login);
            }
        }
    }
}