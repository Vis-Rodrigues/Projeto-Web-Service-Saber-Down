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
    public class AlternativaIdenForController : ApiController
    {

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/alternativaIdenFor
        public IEnumerable<AlternativaIdenForme> Get()
        {
            var alternativasIdenFor = _unit.AlternativaIdenForRepository.Listar();
            return alternativasIdenFor;
        }

        // GET api/alternativaIdenFor/id
        public IEnumerable<AlternativaIdenForme> Get(int id)
        {
            var alternativasIdenFor = _unit.AlternativaIdenForRepository.BuscarPorQuestao(id);
            if (alternativasIdenFor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return alternativasIdenFor;
        }

        // POST api/alternativaIdenFor
        public HttpResponseMessage Post(AlternativaIdenForme alternativaIdenFor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.AlternativaIdenForRepository.Cadastrar(alternativaIdenFor);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, alternativaIdenFor);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = alternativaIdenFor.AlternativaIdenFormeId }));
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

        // DELETE api/alternativaIdenFor
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.AlternativaIdenForRepository.Deletar(id);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));
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
