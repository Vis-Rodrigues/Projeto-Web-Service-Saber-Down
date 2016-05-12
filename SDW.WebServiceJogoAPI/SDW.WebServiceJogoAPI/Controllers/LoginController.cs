using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDW.WebServiceJogoAPI.Controllers
{
    public class LoginController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        //Post api/login
        public Usuario Post(Usuario usuario)
        {
            IEnumerable<Usuario> user = _unit.UsuarioRepository.BuscarPorUsuarioSenha(usuario.Descricao, usuario.Senha);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));               
            }
            else
            {
                foreach(Usuario u in user)
                {
                    return u;
                }
            }
            Usuario us = new Usuario();
            us.UsuarioId = -1;
            return us;
        }

    }
}
