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
            popularBanco();
            var pontuacoes = _unit.PontuacaoRepository.Listar();
            return pontuacoes;
        }

        // GET api/pontuacao/id
        public Pontuacao Get(int id)
        {
            Pontuacao pontuacao = _unit.PontuacaoRepository.BuscarPorUsuario(id);
            if (pontuacao == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pontuacao;
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
            if (ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != pontuacao.UsuarioId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            _unit.PontuacaoRepository.Atualizar(pontuacao);
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

        private void popularBanco()
        {
            Usuario u = new Usuario();
            u = _unit.UsuarioRepository.BuscarPorCodigo(1);
            Pontuacao p = new Pontuacao();
            p.UsuarioId = u.UsuarioId;
            p.Usuario = u;
            p.Moeda = 10;
            p.Ponto = 10;

            Post(p);

        }


    }
}
