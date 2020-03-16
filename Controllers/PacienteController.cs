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
    public class PacienteController : Controller
    {
        protected Contexto myContexto;

        public PacienteController(Contexto contexto)
        {
            myContexto = contexto;
        }

        public IActionResult Index()
        {

            IEnumerable<Paciente> Lista = myContexto.Paciente.ToList();
            myContexto.Dispose();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            PacienteViewModel viewPaciente = new PacienteViewModel();
            viewPaciente.ListaCidade = ListaCidade();

            if (id != 0)
            {
                Paciente paciente = myContexto.Paciente.Where(c => c.Codigo == id).FirstOrDefault();
                viewPaciente.Codigo = paciente.Codigo;
                viewPaciente.Nome = paciente.Nome;
                viewPaciente.Endereco = paciente.Endereco;
                viewPaciente.Bairro = paciente.Bairro;
                viewPaciente.Numero = paciente.Numero;
                viewPaciente.CidadeCodigo = paciente.CidadeCodigo;
                viewPaciente.Telefone = paciente.Telefone;
                viewPaciente.Email = paciente.Email;
                viewPaciente.Profissao = paciente.Profissao;
            }

            return View(viewPaciente);
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
        public IActionResult Cadastro(PacienteViewModel paciente)
        {
            if (ModelState.IsValid)
            {
                Paciente objPaciente = new Paciente()
                {
                    Codigo = paciente.Codigo,
                    Nome = paciente.Nome,
                    Endereco = paciente.Endereco,
                    Bairro = paciente.Bairro,
                    Numero = paciente.Numero,
                    Telefone = paciente.Telefone,
                    Email = paciente.Email,
                    Profissao = paciente.Profissao,
                };

                if (paciente.Codigo == null)
                {
                    myContexto.Paciente.Add(objPaciente);
                }
                else
                {
                    myContexto.Entry(objPaciente).State = EntityState.Modified;
                }

                myContexto.SaveChanges();
            }
            else
            {
                paciente.ListaCidade = ListaCidade();
                return View(paciente);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Paciente paciente = new Paciente() { Codigo = id };
            myContexto.Attach(paciente);
            myContexto.Remove(paciente);
            myContexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
