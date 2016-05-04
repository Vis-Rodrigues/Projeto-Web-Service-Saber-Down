using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class AlternativaComPreMon
    {
        public int AlternativaComPreMonId { get; set; }

        [Required]
        [MaxLength(20)]
        public String Descricao { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoId { get; set; }

    }
}