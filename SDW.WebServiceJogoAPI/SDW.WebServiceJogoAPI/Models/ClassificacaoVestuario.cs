using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class ClassificacaoVestuario
    {
        public int ClassificacaoVestuarioId { get; set; }

        [Required]
        [MaxLength(20)]
        public String Descricao { get; set; }

        public virtual ICollection<Vestuario>  Vestuarios { get; set; }
    }
}