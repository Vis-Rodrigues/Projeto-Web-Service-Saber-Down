using SDW.WebServiceJogo.MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using System.Linq.Expressions;
using SDW.WebServiceJogoAPI.Models.Abstract;
using SendGrid;
using System.Net.Mail;
using System.Net;

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
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario EnviarEmail(string email)
        {
           
            Usuario usuario = _context.Usuarios.Where(s => s.Email.Equals(email)).FirstOrDefault();
            if(usuario != null)
            {
                Random r = new Random();
                int codigo = r.Next(10000, 99999);
                usuario.Senha = codigo.ToString();

                // Create the email object first, then add the properties.
                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(email);
                myMessage.From = new MailAddress("jogosaberdown@gmail.com", "Saber Down");
                myMessage.Subject = "Redefinir Senha Jogo Saber Down";
                myMessage.Text = "Olá "+usuario.Descricao +"!\n\n Recebemos uma solicitação para redefinir senha.\n\n Acesse o aplicativo e informe a senha temporária: " + usuario.Senha + " \n\n Após o login, informe uma nova senha de acordo com a sua preferência.\n\n Estamos à disposição para eventuais dúvidas. \n\n\n Atenciosamente, \n\nJogo Saber Down\n\njogosaberdown@gmail.com";

                // Create a Web transport, using API Key
                var credentials = new NetworkCredential("6309390d-cccf-4622-83d3-81cd593dbead@apphb.com", "ln6nhjm98702");
                var transportWeb = new Web(credentials);
                //var transportWeb = new Web("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");
                //var transportWeb = new Web("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");
                
                
                // Send the email.
                transportWeb.DeliverAsync(myMessage);
            }

            return usuario;
        }
        
        public void Deletar(int codigo)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(codigo));
        }
    }
}
