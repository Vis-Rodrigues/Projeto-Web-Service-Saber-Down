﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class PontuacaoRepository : IPontuacaoRepository
    {
        private JogoContext _context;

        public PontuacaoRepository(JogoContext context)
        {
            _context = context;
        }

        public void Atualizar(Pontuacao pontuacao)
        {
            _context.Entry(pontuacao).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<Pontuacao> BuscarPorUsuario(int id)
        {
            return _context.Pontuacoes.Where(p => p.UsuarioId == id).ToList();
        }

        public void Cadastrar(Pontuacao pontuacao)
        {
            _context.Pontuacoes.Add(pontuacao);
        }

        public ICollection<Pontuacao> Listar()
        {
            return _context.Pontuacoes.OrderByDescending(p => p.Ponto).ToList();
        }
        
        public void Deletar(int codigo)
        {
            _context.Pontuacoes.Remove(_context.Pontuacoes.Find(codigo));
        }
    }
}
