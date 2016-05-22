using SDW.WebServiceJogo.MVC.Contexts;
using SDW.WebServiceJogo.MVC.Repositories;
using SDW.WebServiceJogoAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.UnitsofWorks
{
    public class UnitOfWork : IDisposable
    {
        private JogoContext _context = new JogoContext();

        private IAlternativaIdenForRepository _alternativaIdenForRepository;

        public IAlternativaIdenForRepository AlternativaIdenForRepository
        {
            get
            {
                if (_alternativaIdenForRepository == null)
                {
                    _alternativaIdenForRepository =
                        new AlternativaIdenForRepository(_context);
                }
                return _alternativaIdenForRepository;
            }
        }

        private IGuardaRoupaRepository _guardaRoupaRepository;
        
        public IGuardaRoupaRepository GuardaRoupaRepository
        {
            get
            {
                if (_guardaRoupaRepository == null)
                {
                    _guardaRoupaRepository =
                        new GuardaRoupaRepository(_context);
                }
                return _guardaRoupaRepository;
            }
        }

        private IPontuacaoRepository _pontuacaoRepository;

        public IPontuacaoRepository PontuacaoRepository
        {
            get
            {
                if (_pontuacaoRepository == null)
                {
                    _pontuacaoRepository =
                        new PontuacaoRepository(_context);
                }
                return _pontuacaoRepository;
            }
        }

        private IQuestaoRepository _questaoRepository;

        public IQuestaoRepository QuestaoRepository
        {
            get
            {
                if (_questaoRepository == null)
                {
                    _questaoRepository =
                        new QuestaoRepository(_context);
                }
                return _questaoRepository;
            }
        }

        private IQuestaoUsuarioRepository _questaoUsuarioRepository;

        public IQuestaoUsuarioRepository QuestaoUsuarioRepository
        {
            get
            {
                if (_questaoUsuarioRepository == null)
                {
                    _questaoUsuarioRepository =
                        new QuestaoUsuarioRepository(_context);
                }
                return _questaoUsuarioRepository;
            }
        }

        private IUsuarioRepository _usuarioRepository;

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository =
                        new UsuarioRepository(_context);
                }
                return _usuarioRepository;
            }
        }

        private IVestuarioRepository _vestuarioRepository;

        public IVestuarioRepository VestuarioRepository
        {
            get
            {
                if (_vestuarioRepository == null)
                {
                    _vestuarioRepository =
                        new VestuarioRepository(_context);
                }
                return _vestuarioRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}