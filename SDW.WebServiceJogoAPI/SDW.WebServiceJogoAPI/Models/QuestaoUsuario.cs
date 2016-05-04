using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class QuestaoUsuario
    {
        public int QuestaoUsuarioId { get; set; }

        [Required]
        public bool Acerto { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoId { get; set; }

    }
}