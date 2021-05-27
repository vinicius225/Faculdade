using Faculdade.Banco;
using Faculdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculdade.Controllers
{
    public class CursosController : Controller
    {
        CrudCurso crudC = new CrudCurso();
        // GET: Cursos
    
        public ActionResult Index()
        {
            var resultado = crudC.Consultar();
            return View(resultado);
        }
     
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Curso curso)
        {
            crudC.adicionar(curso);
            return RedirectToAction("Index");
        }
        public ActionResult Disciplina(int? id)
        {
            var resultado = crudC.Disciplina(id.Value);
            return View(resultado);
        }
        public ActionResult Editar(int? id)
        {
            var resultado = crudC.consultarID(id.Value);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Curso curso)
        {
            if(curso.codigo != null)
            {
                crudC.atualizar(curso);
                return RedirectToAction("Index");
            }
            else
            {
                return View ();
            }
        
         
        }
        public ActionResult Excluir(int? id)
        {
            if (id.HasValue) { 
            crudC.excluir(id.Value);
            }
            return RedirectToAction("Index");
        }
        public ActionResult CadDisciplina()
        {
            ViewBag.Curso =crudC.Consultar();
            ViewBag.Professor = crudC.ConsultarProfessor();
            return View();
        }
        [HttpPost]
        public ActionResult CadDisciplina(int? id, Disciplina disciplina)
        {
            crudC.CadastroDisciplina(id.Value, disciplina);
            return RedirectToAction("Index");
        }

    }
}