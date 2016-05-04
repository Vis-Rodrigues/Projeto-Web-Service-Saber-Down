using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class ClassificacaoRepository : IClassificacaoRepository
    {
        private JogoContext _context;

        public ClassificacaoRepository(JogoContext context)
        {
            _context = context;
        }

        public void Cadastrar(ClassificacaoVestuario classificacao)
        {
            _context.ClassificacaoVestuarios.Add(classificacao);
        }

        public ICollection<ClassificacaoVestuario> Listar()
        {
            return _context.ClassificacaoVestuarios.ToList();
        }

    }
}