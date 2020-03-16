using Agendamento.DAL;
using Agendamento.Entidades;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Controllers
{
    public class UsuarioController : Controller
    {
        protected Contexto myContexto;

        public UsuarioController(Contexto contexto)
        {
            myContexto = contexto;
        }

        public IActionResult Index()
        {

            IEnumerable<Usuario> Lista = myContexto.Usuario.ToList();
            myContexto.Dispose();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            UsuarioViewModel viewUsaurio = new UsuarioViewModel();

            if (id != 0)
            {
                Usuario usuario = myContexto.Usuario.Where(c => c.Codigo == id).FirstOrDefault();
                viewUsaurio.Codigo = usuario.Codigo;
                viewUsaurio.Nome = usuario.Nome;
                viewUsaurio.Senha = usuario.Senha;
                viewUsaurio.Email = usuario.Email;
            }

            return View(viewUsaurio);
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioViewModel Usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario objUsuario = new Usuario()
                {
                    Codigo = Usuario.Codigo,
                    Nome = Usuario.Nome,
                    Email = Usuario.Email
                };

                if (Usuario.Codigo == null)
                {
                    myContexto.Usuario.Add(objUsuario);
                }
                else
                {
                    myContexto.Entry(objUsuario).State = EntityState.Modified;
                }

                myContexto.SaveChanges();
            }
            else
            {
                return View(Usuario);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Usuario usuario = new Usuario() { Codigo = id };
            myContexto.Attach(usuario);
            myContexto.Remove(usuario);
            myContexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
