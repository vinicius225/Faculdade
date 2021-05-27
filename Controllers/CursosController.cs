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
            return RedirectToAction("Cursos");
        }
        public ActionResult Disciplina(int? id)
        {
            var resultado = crudC.Disciplina(id.Value);
            return View(resultado);
        }
       

    }
}