using Faculdade.Banco;
using Faculdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculdade.Controllers
{
    public class AlunoController : Controller
    {
        CrudAluno crudU = new CrudAluno();
        CrudCurso CrudC = new CrudCurso();
        // GET: Aluno
        public ActionResult Index()
        {

            var resultado = crudU.Consultar();
            return View(resultado);
        }
        public ActionResult Cadastro()
        {
            ViewBag.Curso = CrudC.Consultar();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {
            crudU.adicionar(aluno);
            return Redirect("Index");

        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Curso = CrudC.Consultar();

            Aluno aluno = crudU.consultarID(id.Value);
            return View(aluno);
        }
   
        [HttpPost]
        public ActionResult Editar (Aluno aluno)
        {
            crudU.atualizar(aluno);
            return Redirect("Index");
        }
   
        public ActionResult Nota()
        {
            var resultado = crudU.nota();
            return View(resultado);
        }
        public ActionResult EditarNota(int? id)
        {
            List<Nota> resultado = crudU.notaId(id.Value);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult EditarNota (Aluno aluno)
        {
            crudU.atualizarNota(aluno);
            return View();
        }
        public ActionResult Excluir(int? id)
        {
            if (id.HasValue) {
                crudU.excluir(id.Value);
                    }
            return RedirectToAction("Index");
        }



    }    
   
}