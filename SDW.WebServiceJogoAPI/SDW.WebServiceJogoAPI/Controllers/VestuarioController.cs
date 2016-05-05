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
    public class VestuarioController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET api/vestuario
        public IEnumerable<Vestuario> Get()
        {
            var vestuarios = _unit.VestuarioRepository.Listar();
            return vestuarios;
        }

        // GET api/vestuario/id
        public IEnumerable<Vestuario> Get(int id)
        {
            var vestuarios = _unit.VestuarioRepository.BuscarPorClassificacao(id);
            return vestuarios;
        }

        // POST api/vestuario
        public HttpResponseMessage Post(Vestuario vestuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.VestuarioRepository.Cadastrar(vestuario);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, vestuario);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = vestuario.VestuarioId }));
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
