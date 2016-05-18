﻿using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using System.Linq.Expressions;
using SDW.WebServiceJogoAPI.Models.Abstract;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class UsuarioRepository :IUsuarioRepository
    {
        private JogoContext _context;
        private Hash hash;
        private Guid guid = Guid.NewGuid();

        public UsuarioRepository(JogoContext context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
        }

        public Usuario BuscarPorCodigo(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario BuscarPorUsuarioSenha(String usuario, String senha)
         {
            //hash.CriptografarSenha(senha+guid.ToString())
            return (Usuario)_context.Usuarios.Where(s => s.Descricao.Equals(usuario) && s.Senha.Equals(senha));
         }

        public void Cadastrar(Usuario usuario)
        {
            
           // String senha = usuario.Senha;
            //usuario.Senha = hash.CriptografarSenha(senha + guid.ToString());
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

    }
}