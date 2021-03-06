using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faculdade.Models
{
    public class Professor
    {
        public int codigo { get; set; }
        [Display(Name ="Nome do Professor:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string nome { get; set; }
    }
}