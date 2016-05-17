using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Repositories;
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
    public class PontuacaoController : ApiController
    {
        private IPontuacaoRepository _pontuacaoRepository { get; set; }

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/pontuacao
        public IEnumerable<Pontuacao> Get()
        {
            var pontuacoes = _unit.PontuacaoRepository.Listar();
            return pontuacoes;
        }

        // GET api/pontuacao/id
        public IEnumerable<Pontuacao> Get(int id)
        {
            var pontuacoes = _unit.PontuacaoRepository.BuscarPorUsuario(id);
            return pontuacoes;
        }

        // POST api/pontuacao
        public HttpResponseMessage Post(Pontuacao pontuacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.PontuacaoRepository.Cadastrar(pontuacao);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, pontuacao);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = pontuacao.UsuarioId }));
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

        //PUT api/pontuacao/5
        public HttpResponseMessage Put(int id, Pontuacao pontuacao)
        {
            if (id != pontuacao.PontuacaoId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                _unit.PontuacaoRepository.Atualizar(pontuacao);
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
