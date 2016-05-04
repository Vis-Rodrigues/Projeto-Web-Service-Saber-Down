using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class AlternativaComPreRepository : IAlternativaComPreRepository
    {
        private JogoContext _context;

        public AlternativaComPreRepository(JogoContext context)
        {
            _context = context;
        }

        public ICollection<AlternativaComPreMon> BuscarPorQuestao(int questaoId)
        {
            return _context.AlternativasComPreMon.Include("Questao").Where(q => q.QuestaoId == questaoId).ToList();
        }

        public void Cadastrar(AlternativaComPreMon alternativa)
        {
            _context.AlternativasComPreMon.Add(alternativa);
        }

        public IList<AlternativaComPreMon> Listar()
        {
            return _context.AlternativasComPreMon.Include("Questao").ToList();
        }
    }
}