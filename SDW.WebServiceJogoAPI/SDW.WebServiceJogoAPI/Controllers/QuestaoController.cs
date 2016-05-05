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
    public class QuestaoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET api/questao
        public IEnumerable<Questao> Get()
        {
            var questoes = _unit.QuestaoRepository.Listar();
            return questoes;
        }

        // POST api/questao/{questao}
        public HttpResponseMessage Post(Questao questao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.QuestaoRepository.Cadastrar(questao);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, questao);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = questao.QuestaoId }));
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
