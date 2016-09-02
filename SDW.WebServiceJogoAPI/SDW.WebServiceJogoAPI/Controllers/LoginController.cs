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
using SDW.WebServiceJogoAPI.Utils;

namespace SDW.WebServiceJogoAPI.Controllers
{

    public class LoginController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        //Post api/login
        public HttpResponseMessage Post(Usuario usuario)
        {

            Usuario user = _unit.UsuarioRepository.BuscarPorUsuarioSenha(usuario.Descricao, CriptografiaUtils.CriptografarSHA256(usuario.Senha));

            if (user == null)
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
