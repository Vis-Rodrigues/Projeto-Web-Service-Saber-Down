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

        public Vestuario Vestuario { get; set; }
        public int VestuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}