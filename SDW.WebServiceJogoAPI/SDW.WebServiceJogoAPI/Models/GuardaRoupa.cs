using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class GuardaRoupa
    {
        public int GuardaRoupaId { get; set; }

        [Required]
        public bool RoupaUtilizada { get; set; }

        [Required]
        public int VestuarioId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

    }
}