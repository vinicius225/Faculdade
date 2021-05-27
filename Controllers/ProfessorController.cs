﻿using Faculdade.Banco;
using Faculdade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculdade.Controllers
{

    public class ProfessorController : Controller
    {
        CrudProfessor crudP = new CrudProfessor();
        CrudCurso crudC = new CrudCurso();
        // GET: Professor
        public ActionResult Index()
        {
            var resultado = crudP.Consultar();
            return View(resultado);
        }

        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Professor professor)
        {
            crudP.adicionar(professor);
            return RedirectToAction("Index");
        }
        public ActionResult Disciplina(int? id)
        {
            var resultado = crudC.DisciplinaIdProfessor(id.Value);
            return View(resultado);

        }
        public ActionResult Editar(int? id)
        {
            var resultado = crudC.atualizar(id.Value);
            return View(resultado);

        }
    }
}