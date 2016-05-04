using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class AlternativaIdenForme
    {
        public int AlternativaIdenFormeId { get; set; }

        [Required]
        [MaxLength(30)]
        public String Descricao { get; set; }

        public bool Correta { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoId { get; set; }
    }
}