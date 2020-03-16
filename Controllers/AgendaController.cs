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
    public class AgendaController : Controller
    {
        protected Contexto myContexto;

        public AgendaController(Contexto contexto)
        {
            myContexto = contexto;
        }

        public IActionResult Index()
        {

            IEnumerable<Agenda> Lista = myContexto.Agenda.ToList();
            myContexto.Dispose();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            AgendaViewModel viewAgenda = new AgendaViewModel();

            if (id != 0)
            {
                Agenda agenda = myContexto.Agenda.Where(c => c.Codigo == id).FirstOrDefault();
                viewAgenda.Codigo = agenda.Codigo;
            }

            return View(viewAgenda);
        }

        [HttpPost]
        public IActionResult Cadastro(AgendaViewModel agenda)
        {
            if (ModelState.IsValid)
            {
                Agenda objAgenda = new Agenda()
                {
                    Codigo = agenda.Codigo,
                };

                if (agenda.Codigo == null)
                {
                    myContexto.Agenda.Add(objAgenda);
                }
                else
                {
                    myContexto.Entry(objAgenda).State = EntityState.Modified;
                }

                myContexto.SaveChanges();
            }
            else
            {
                return View(agenda);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Agenda agenda = new Agenda() { Codigo = id };
            myContexto.Attach(agenda);
            myContexto.Remove(agenda);
            myContexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
