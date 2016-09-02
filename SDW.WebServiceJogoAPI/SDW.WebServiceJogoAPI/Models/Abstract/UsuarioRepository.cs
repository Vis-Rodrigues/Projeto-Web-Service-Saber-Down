﻿using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using System.Linq.Expressions;
using SDW.WebServiceJogoAPI.Models.Abstract;
using SendGrid;
using System.Net.Mail;
using SDW.WebServiceJogoAPI.Utils;

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
            return _context.Usuarios.Where(s => s.Descricao.Equals(usuario) && s.Senha.Equals(senha)).FirstOrDefault();
         }

        public void Cadastrar(Usuario usuario)
        {

            // String senha = usuario.Senha;
            //usuario.Senha = hash.CriptografarSenha(senha + guid.ToString());
            usuario.Senha = CriptografiaUtils.CriptografarSHA256(usuario.Senha);
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario EnviarEmail(string email)
        {
            // email: jogosaberdown@gmail.com
            // senha: saberdownjogo
            // sendgrid user: JogoSaberDown
            // senha: saberdown2016
            Usuario usuario = _context.Usuarios.Where(s => s.Email.Equals(email)).FirstOrDefault();
            if(usuario != null)
            {
                Random r = new Random();
                int codigo = r.Next(10000, 99999);
                usuario.Senha = CriptografiaUtils.CriptografarSHA256(codigo.ToString());

                // Create the email object first, then add the properties.
                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(email);
                myMessage.From = new MailAddress("jogosaberdown@gmail.com", "Saber Down");
                myMessage.Subject = "Nova Senha";
                myMessage.Text = "Olá "+usuario.Descricao +"!\n\n Sua nova senha é: " + codigo + " \n\nAtenciosamente, \nJogo Saber Down";

                // Create a Web transport, using API Key
                var transportWeb = new Web("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");

                // Send the email.
                transportWeb.DeliverAsync(myMessage);
            }

            return usuario;
        }
    }
}