﻿using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using SDW.WebServiceJogoAPI.Models;
using SDW.WebServiceJogoAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDW.WebServiceJogoAPI.Controllers
{
    public class UserPointController : ApiController
    { 
        private UnitOfWork _unit = new UnitOfWork();

        private ICollection<UserPoint> lista;

        // GET api/pontuacao
        public IEnumerable<UserPoint> Get()
        {
            var pontuacoes = Popular();
            return pontuacoes;
        }

        private ICollection<UserPoint> Popular()
        {
           foreach(Pontuacao p in _unit.PontuacaoRepository.Listar()){
                UserPoint userPoint = new UserPoint();
                userPoint.PontuacaoId = p.PontuacaoId;
                userPoint.Moeda = p.Moeda;
                userPoint.Ponto = p.Ponto;
                userPoint.UsuarioId = p.UsuarioId;
                Usuario u = new Usuario();
                u = _unit.UsuarioRepository.BuscarPorCodigo(userPoint.UsuarioId);
                userPoint.Descricao = u.Descricao;
                userPoint.Email = u.Email;
                userPoint.Genero = u.Genero;
                userPoint.Senha = u.Senha;
                lista.Add(userPoint);
            }
            return lista;
        }
    }
}