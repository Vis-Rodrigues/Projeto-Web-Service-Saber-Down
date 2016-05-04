using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Contexts
{
    public class JogoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<AlternativaComPreMon> AlternativasComPreMon { get; set; }

        public DbSet<AlternativaIdenForme> AlternativasIdenForme { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ClassificacaoVestuario> ClassificacaoVestuarios { get; set; }

        public DbSet<GuardaRoupa> GuardaRoupas { get; set; }

        public DbSet<Pontuacao> Pontuacoes { get; set; }

        public DbSet<Questao> Questoes { get; set; }

        public DbSet<QuestaoUsuario> QuestaoUsuarios { get; set; }

        public DbSet<Vestuario> Vestuarios { get; set; }

        public JogoContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}