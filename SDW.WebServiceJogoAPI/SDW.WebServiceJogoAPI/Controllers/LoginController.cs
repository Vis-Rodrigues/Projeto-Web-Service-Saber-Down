using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SDW.WebServiceJogoAPI.Controllers
{

    public class LoginController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();
        
        //Post api/login
        public HttpResponseMessage Post(String nome, String senha)
        {
                
            Usuario user = _unit.UsuarioRepository.BuscarPorUsuarioSenha(nome, senha);
            if(user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuario Não Encontrado!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

        }

    }
}
