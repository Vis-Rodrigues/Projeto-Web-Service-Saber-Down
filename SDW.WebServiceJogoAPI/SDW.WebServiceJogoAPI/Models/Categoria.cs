using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(40)]
        public String Descricao { get; set; }

        [Required]
        public int Ponto { get; set; }

        public virtual ICollection<Questao> Questoes { get; set; }
    }
}