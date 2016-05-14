using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Questao
    {
        public int QuestaoId { get; set; }
   
        [MaxLength(300)]
        public String Descricao { get; set; }

        public int CategoriaId { get; set; }

        public int AlternativaIdenFormeId { get; set; }

    }
}