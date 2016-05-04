using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using System.Linq.Expressions;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class VestuarioRepository : IVestuarioRepository
    {
        private JogoContext _context;

        public VestuarioRepository(JogoContext context)
        {
            _context = context;
        }

        public ICollection<Vestuario> Listar()
        {
            return _context.Vestuarios.Include("ClassificacaoVestuario").ToList();
        }

        public ICollection<Vestuario> BuscarPorCodigo(int codigo)
        {
            return _context.Vestuarios.Include("ClassificacaoVestuario").Where(v => v.VestuarioId == codigo).ToList();
        }

        public void Cadastrar(Vestuario vestuario)
        {
            _context.Vestuarios.Add(vestuario);
        }

        public ICollection<Vestuario> BuscarPorClassificacao(int classificacaoId)
        {
            return _context.Vestuarios.Include("ClassificacaoVestuario").Where(v => v.ClassificacaoVestuarioId == classificacaoId).ToList();
        }
    }
}