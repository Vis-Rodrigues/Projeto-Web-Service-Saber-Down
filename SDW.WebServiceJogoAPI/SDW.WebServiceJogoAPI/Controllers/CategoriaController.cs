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
    public class CategoriaController : ApiController
    {
        private ICategoriaRepository _categoriaRepository { get; set; }

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/categoria
        public IEnumerable<Categoria> Get()
        {
            var categorias = _unit.CategoriaRepository.Listar();
            return categorias;
        }

        // POST api/categoria/{categoria}
        public HttpResponseMessage Post(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.CategoriaRepository.Cadastrar(categoria);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categoria);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categoria.CategoriaId }));
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
