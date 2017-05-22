using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Pontuacao
    {
       
        public int PontuacaoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        public int Ponto { get; set; }

        [Required]
        public int Moeda { get; set; }

        [Required]
        public int Acerto { get; set; }

        [Required]
        public int Erro { get; set; }
    }
}