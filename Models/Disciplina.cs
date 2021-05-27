using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faculdade.Models
{
    public class Disciplina
    {
        public int codigo { get; set; }
        public int codigoProfessor { get; set; }

        [Display(Name ="Nome do Curso:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string nomeCurso { get; set; }

        [Display(Name = "Nome da disciplina:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string nomeDisciplina { get; set; }

        [Display(Name = "horario aula")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string horarioAula { get; set; }

        [Display(Name = "Nome do professor:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string nomeProfessor { get; set; }
    }
}