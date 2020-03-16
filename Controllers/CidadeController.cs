using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.DAL;
using Agendamento.Entidades;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Controllers
{
    public class CidadeController : Controller
    {

        protected Contexto myContexto;

        public CidadeController(Contexto contexto)
        {
            myContexto = contexto;
        }

        public IActionResult Index()
        {

            IEnumerable<Cidade> Lista = myContexto.Cidade.ToList();
            myContexto.Dispose();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            CidadeViewModel viewCidade = new CidadeViewModel();
            viewCidade.ListaEstado = ListaEstado();

            if (id != 0)
            {
                Cidade cidade = myContexto.Cidade.Where(c => c.Codigo == id).FirstOrDefault();
                viewCidade.Codigo = cidade.Codigo;
                viewCidade.Nome = cidade.Nome;
                viewCidade.UF = cidade.UF;
            }

            return View(viewCidade);
        }

        public IEnumerable<SelectListItem> ListaEstado()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = "Selecione o estado"
            });

            foreach (var item in myContexto.Estado.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Sigla,
                    Text = item.Sigla
                });
            };

            return lista;
        }

        [HttpPost]
        public IActionResult Cadastro(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                Cidade objCidade = new Cidade()
                {
                    Codigo = cidade.Codigo,
                    Nome = cidade.Nome,
                    UF = cidade.UF
                };

                if (cidade.Codigo == null)
                {
                    myContexto.Cidade.Add(objCidade);
                }
                else
                {
                    myContexto.Entry(objCidade).State = EntityState.Modified;
                }

                myContexto.SaveChanges();
            }
            else
            {
                cidade.ListaEstado = ListaEstado();
                return View(cidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Cidade cidade = new Cidade() { Codigo = id };
            myContexto.Attach(cidade);
            myContexto.Remove(cidade);
            myContexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}