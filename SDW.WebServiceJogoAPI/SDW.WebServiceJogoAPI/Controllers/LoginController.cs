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
                if (ModelState.IsValid)
                {
                    IEnumerable<Usuario> user = _unit.UsuarioRepository.BuscarPorUsuarioSenha(nome, senha);
                    Usuario usuario = new Usuario();
                    foreach (Usuario u in user)
                    {
                        usuario = u;                        
                    }
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.UsuarioId }));
                    return response;
                    
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            
            
        }

    }
}
