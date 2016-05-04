using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Vestuario
    {
        public int VestuarioId { get; set; }

        public String Imagem { get; set; }

        [Required]
        public int Preco { get; set; }

        public ClassificacaoVestuario ClassificacaoVestuario { get; set; }
        public int ClassificacaoVestuarioId { get; set; }

        public virtual ICollection<GuardaRoupa> GuardaRoupas { get; set; }
    }
}