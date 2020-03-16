using Agendamento.DAL;
using Agendamento.Entidades;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Controllers
{
    public class MedicoController : Controller
    {
        protected Contexto myContexto;

        public MedicoController(Contexto contexto)
        {
            myContexto = contexto;
        }

        public IActionResult Index()
        {

            IEnumerable<Medico> Lista = myContexto.Medico.ToList();
            myContexto.Dispose();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            MedicoViewModel viewMedico = new MedicoViewModel();
            viewMedico.ListaCidade = ListaCidade();

            if (id != 0)
            {
                Medico medico = myContexto.Medico.Where(c => c.Codigo == id).FirstOrDefault();
                viewMedico.Codigo = medico.Codigo;
                viewMedico.Nome = medico.Nome;
                viewMedico.Endereco = medico.Endereco;
                viewMedico.Bairro = medico.Bairro;
                viewMedico.Numero = medico.Numero;
                viewMedico.CidadeCodigo = medico.CidadeCodigo;
                viewMedico.Telefone = medico.Telefone;
                viewMedico.Email = medico.Email;
                viewMedico.Especialidade = medico.Especialidade;
            }

            return View(viewMedico);
        }

        public IEnumerable<SelectListItem> ListaCidade()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = "Selecione a cidade"
            });

            foreach (var item in myContexto.Cidade.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                });
            };

            return lista;
        }

        [HttpPost]
        public IActionResult Cadastro(MedicoViewModel medico)
        {
            if (ModelState.IsValid)
            {
                Medico objMedico = new Medico()
                {
                    Codigo = medico.Codigo,
                    Nome = medico.Nome,
                };

                if (medico.Codigo == null)
                {
                    myContexto.Medico.Add(objMedico);
                }
                else
                {
                    myContexto.Entry(objMedico).State = EntityState.Modified;
                }

                myContexto.SaveChanges();
            }
            else
            {
                medico.ListaCidade = ListaCidade();
                return View(medico);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Medico medico = new Medico() { Codigo = id };
            myContexto.Attach(medico);
            myContexto.Remove(medico);
            myContexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
