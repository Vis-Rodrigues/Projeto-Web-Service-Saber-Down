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
            var usuarios = _unit.UsuarioRepository.Listar();
            return usuarios;
        }

        // GET api/usuario/{id}
        public Usuario Get(int id)
        {
            return _unit.UsuarioRepository.BuscarPorCodigo(id);
        }

        // POST api/usuario
        /*public HttpResponseMessage Post(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unit.UsuarioRepository.Cadastrar(usuario);
                    _unit.Save();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.UsuarioId}));
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
        }*/

        //PUT api/usuario/5
        public HttpResponseMessage Put(int id, Usuario usuario)
        {
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

        //Post api/login
        public HttpResponseMessage Post(Usuario usuario)
        {

            Usuario user = _unit.UsuarioRepository.BuscarPorUsuarioSenha(usuario.Descricao, usuario.Senha);

            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuario Não Encontrado!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

        }


    }
}
