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
    public class QuestaoUsuarioController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET api/questaoUsuario
        public IEnumerable<QuestaoUsuario> Get()
        {
            var questoesUsuario = _unit.QuestaoUsuarioRepository.Listar();
            return questoesUsuario;
        }

        // GET api/questaoUsuario/id
        public IEnumerable<QuestaoUsuario> Get(int id)
        {
            var questoesUsuario = _unit.QuestaoUsuarioRepository.BuscarPorUsuario(id);
            return questoesUsuario;
        }

        // POST api/questaoUsuario
        public HttpResponseMessage Post(QuestaoUsuario questaoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.QuestaoUsuarioRepository.Cadastrar(questaoUsuario);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, questaoUsuario);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = questaoUsuario.QuestaoId }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
