using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class GuardaRoupaRepository : IGuardaRoupaRepository
    {
        private JogoContext _context;

        public GuardaRoupaRepository(JogoContext context)
        {
            _context = context;
        }

        public void Atualizar(GuardaRoupa guardaRoupa)
        {
            _context.Entry(guardaRoupa).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<GuardaRoupa> BuscarPorUsuario(int codigoUsuario)
        {
            return _context.GuardaRoupas.Include("Vestuario").Include("Usuario").Where(p => p.Usuario.UsuarioId == codigoUsuario).ToList();
        }

        public void Cadastrar(GuardaRoupa guardaRoupa)
        {
            _context.GuardaRoupas.Add(guardaRoupa);
        }

        public ICollection<GuardaRoupa> Listar()
        {
            return _context.GuardaRoupas.Include("Vestuario").Include("Usuario").ToList();
        }
    }
}