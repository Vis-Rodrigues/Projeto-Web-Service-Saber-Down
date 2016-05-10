using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique =true)]
        public String Descricao { get; set; }

        [Required]
        [MaxLength(6)]
        public String Senha { get; set; }

        [Required]
        public String Genero { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public String Email { get; set; }

        public virtual ICollection<QuestaoUsuario> QuestaoUsuarios { get; set; }

        public virtual ICollection<GuardaRoupa> GuardaRoupas { get; set; }

    }
}