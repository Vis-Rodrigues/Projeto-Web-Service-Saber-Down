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
    public class UsuarioController : ApiController
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        private UnitOfWork _unit = new UnitOfWork();

        // GET api/usuario
        public IEnumerable<Usuario> GetUsuarios()
        {
            popularBanco();
            var usuarios = _unit.UsuarioRepository.Listar();
            return usuarios;
        }

        // GET api/usuario/{id}
        public Usuario Get(int id)
        {
            return _unit.UsuarioRepository.BuscarPorCodigo(id);
        }

        // POST api/usuario
        public HttpResponseMessage Post(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.UsuarioRepository.Cadastrar(usuario);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.UsuarioId }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        //PUT api/usuario/5
        public HttpResponseMessage Put(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if(id != usuario.UsuarioId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            _unit.UsuarioRepository.Atualizar(usuario);
            try
            {
                _unit.Save();
            }catch(DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private void popularBanco()
        {
            Usuario u = new Usuario();
            u.Genero = "0";
            u.Descricao = "admin";
            u.Senha = "123456";
            u.Email = "vi_ale10@hotmail.com";

            Post(u);
        }
    }
}
