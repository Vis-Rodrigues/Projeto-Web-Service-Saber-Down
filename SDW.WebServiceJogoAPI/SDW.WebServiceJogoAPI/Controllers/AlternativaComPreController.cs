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
    public class AlternativaComPreController : ApiController
    {
        private IAlternativaComPreRepository _alternativaComPreRepository { get; set; }

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/alternativaComPre
        public IEnumerable<AlternativaComPreMon> Get()
        {
            var alternativasComPre = _unit.AlternativaComPreRepository.Listar();
            return alternativasComPre;
        }

        // GET api/alternativaComPre/id
        public IEnumerable<AlternativaComPreMon> Get(int id)
        {
            var alternativasComPre = _unit.AlternativaComPreRepository.BuscarPorQuestao(id);
            if (alternativasComPre == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return alternativasComPre;
        }

        // POST api/alternativaComPre
        public HttpResponseMessage Post(AlternativaComPreMon alternativaComPre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.AlternativaComPreRepository.Cadastrar(alternativaComPre);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, alternativaComPre);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = alternativaComPre.AlternativaComPreMonId }));
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
