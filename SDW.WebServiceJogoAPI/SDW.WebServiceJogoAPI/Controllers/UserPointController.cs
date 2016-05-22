using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using SDW.WebServiceJogoAPI.Models;
using SDW.WebServiceJogoAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDW.WebServiceJogoAPI.Controllers
{
    public class UserPointController : ApiController
    { 
        private UnitOfWork _unit = new UnitOfWork();

        private ICollection<UserPoint> lista = new Collection<UserPoint>();

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
                userPoint.PontuacaoId = 1;
                userPoint.Moeda = 0;
                userPoint.Ponto = 0;
                userPoint.UsuarioId = 4;
                Usuario u = new Usuario();
                u = _unit.UsuarioRepository.BuscarPorCodigo(4);
                userPoint.Descricao = "teste";
                userPoint.Email = "teste@gmail.com";
                userPoint.Genero = "0";
                userPoint.Senha = "123456";
                lista.Add(userPoint);
            }
            return lista;
        }

        public class UserPoint{
      
            public int PontuacaoId { get; set; }

            public int Ponto { get; set; }

            public int Moeda { get; set; }

            public int UsuarioId { get; set; }

            public String Descricao { get; set; }

            public String Senha { get; set; }

            public String Genero { get; set; }

            public String Email { get; set; }
        }
    }
}
