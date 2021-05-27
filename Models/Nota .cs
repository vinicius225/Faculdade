using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faculdade.Models
{
    public class Nota
    {
        public int codigo { get; set; }
        [Display(Name ="Nome do aluno:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string nomeAluno { get; set; }

        [Display(Name = "Nome da disciplina:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string disciplina { get; set; }
        [Display(Name ="Nota")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public double nota { get; set; }
        [Display(Name = "Semestre")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public int semestre { get; set; }
        [Display(Name = "Ano")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public int ano { get; set; }
    }
}
