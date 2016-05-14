using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class AlternativaIdenForRepository : IAlternativaIdenForRepository
    {
        private JogoContext _context;

        public AlternativaIdenForRepository(JogoContext context)
        {
            _context = context;
        }

        public ICollection<AlternativaIdenForme> BuscarPorQuestao(int questaoId)
        {
            return _context.AlternativasIdenForme.Where(q => q.QuestaoId == questaoId).ToList();
        }

        public void Cadastrar(AlternativaIdenForme alternativa)
        {
            _context.AlternativasIdenForme.Add(alternativa);
        }

        public ICollection<AlternativaIdenForme> Listar()
        {
            return _context.AlternativasIdenForme.ToList();
        }
    }
}