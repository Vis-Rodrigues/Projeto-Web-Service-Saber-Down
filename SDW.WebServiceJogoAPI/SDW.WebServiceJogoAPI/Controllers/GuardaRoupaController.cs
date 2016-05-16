using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDW.WebServiceJogoAPI.Controllers
{
    public class GuardaRoupaController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET api/guardaRoupa
        public IEnumerable<GuardaRoupa> Get()
        {
            var guardaRoupas = _unit.GuardaRoupaRepository.Listar();
            return guardaRoupas;
        }

        // GET api/guardaRoupa/id
        public IEnumerable<GuardaRoupa> GetGuardaRoupa(int id)
        {
            var guardaRoupas = _unit.GuardaRoupaRepository.BuscarPorUsuario(id);
            return guardaRoupas;
        }

        // POST api/guardaRoupa
        public HttpResponseMessage Post(GuardaRoupa guardaRoupa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.GuardaRoupaRepository.Cadastrar(guardaRoupa);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, guardaRoupa);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = guardaRoupa.GuardaRoupaId }));
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

        //PUT api/guardaRoupa/5
        public HttpResponseMessage Put(int id, GuardaRoupa guardaRoupa)
        {
            if (id != guardaRoupa.GuardaRoupaId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            _unit.GuardaRoupaRepository.Atualizar(guardaRoupa);
            try
            {
                _unit.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
