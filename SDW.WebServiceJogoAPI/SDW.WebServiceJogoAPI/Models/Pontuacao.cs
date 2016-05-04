using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Pontuacao
    {
                
        [Key]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        [Required]
        public int Ponto { get; set; }

        [Required]
        public int Moeda { get; set; }
    }
}