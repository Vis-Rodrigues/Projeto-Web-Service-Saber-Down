using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using System.Linq.Expressions;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class QuestaoUsuarioRepository : IQuestaoUsuarioRepository
    {
        private JogoContext _context;

        public QuestaoUsuarioRepository(JogoContext context)
        {
            _context = context;
        }

        public void Atualizar(QuestaoUsuario questaoUsuario)
        {
            _context.Entry(questaoUsuario).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<QuestaoUsuario> BuscarPorUsuario(int usuarioId)
        {
            return _context.QuestaoUsuarios.Where(q => q.UsuarioId == usuarioId).ToList();
        }

        public void Cadastrar(QuestaoUsuario questaoUsuario)
        {
            _context.QuestaoUsuarios.Add(questaoUsuario);
        }

        public ICollection<QuestaoUsuario> Listar()
        {
            return _context.QuestaoUsuarios.ToList();
        }
    }
}