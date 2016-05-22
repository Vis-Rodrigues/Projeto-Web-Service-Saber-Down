using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models
{
    public class UserPoint
    {
        public int UserPointId { get; set; }

        [Required]
        public int PontuacaoId { get; set; }

        [Required]
        public int Ponto { get; set; }

        [Required]
        public int Moeda { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
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
    }
}