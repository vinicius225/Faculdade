using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faculdade.Models
{
    public class Aluno
    {
        public int codigo { get; set; }
        [Display(Name ="Curso: ")]
        public int codigoCurso { get; set; }
        [Display(Name ="Nome:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Digite pelo menos 3 caracteres")]
        public string nome { get; set; }
        [Display(Name ="Email:")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email invalido")]
        [Required(ErrorMessage ="Campo obrigsatorio")]
        public string email { get; set; }
        
        public string sexo { get; set; }
        [Display(Name ="Endereço: ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string endereco { get; set; }
        [Display(Name ="Complemento: ")]
        [DataType(DataType.MultilineText)]
        public string complemento { get; set; }
        [Display(Name ="CEP: ")]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string cep { get; set; }
        [Display(Name ="Cidade: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string cidade { get; set; }
        [Display(Name ="Estado:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string estado { get; set; }
        [Display(Name ="Telefone: ")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        public string telefone { get; set; }
        
    }
}