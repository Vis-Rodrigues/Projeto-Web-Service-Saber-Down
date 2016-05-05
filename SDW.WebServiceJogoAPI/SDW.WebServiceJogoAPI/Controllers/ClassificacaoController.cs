using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Repositories;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDW.WebServiceJogoAPI.Controllers
{
    public class ClassificacaoController : ApiController
    {
        private IClassificacaoRepository _classificacaoRepository { get; set; }

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/classificacao
        public IEnumerable<ClassificacaoVestuario> Get()
        {
            var classificacoes = _unit.ClassificacaoRepository.Listar();
            return classificacoes;
        }

        // POST api/classificacao/{classificacao}
        public HttpResponseMessage Post(ClassificacaoVestuario classificacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.ClassificacaoRepository.Cadastrar(classificacao);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, classificacao);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = classificacao.ClassificacaoVestuarioId }));
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
