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

        public String Descricao { get; set; }

        [Required]
        public int Preco { get; set; }

        [Required]
        public int Classificacao { get; set; }
    }
}