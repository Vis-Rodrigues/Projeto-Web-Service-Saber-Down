using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class QuestaoRepository : IQuestaoRepository
    {
        private JogoContext _context;

        public QuestaoRepository(JogoContext context)
        {
            _context = context;
        }

        public void Cadastrar(Questao questao)
        {
            _context.Questoes.Add(questao);
        }

        public ICollection<Questao> Listar()
        {
            return _context.Questoes.Include("Categoria").ToList();
        }
    }
}