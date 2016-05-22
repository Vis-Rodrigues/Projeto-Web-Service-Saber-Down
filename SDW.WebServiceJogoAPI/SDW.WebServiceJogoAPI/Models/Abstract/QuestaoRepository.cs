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

        public ICollection<Questao> BuscarPorCategoria(int id)
        {
            return _context.Questoes.Where(q => q.CategoriaId == id).ToList();
        }

        public void Cadastrar(Questao questao)
        {
            _context.Questoes.Add(questao);
        }

        public void Deletar(int codigo)
        {
            _context.Questoes.Remove(BuscarPorCodigo(codigo));
        }

        public ICollection<Questao> Listar()
        {
            return _context.Questoes.ToList();
        }

        public Questao BuscarPorCodigo(int id)
        {
            return _context.Questoes.Find(id);
        }
    }
}