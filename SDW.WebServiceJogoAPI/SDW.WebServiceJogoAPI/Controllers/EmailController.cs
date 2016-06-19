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
    public class EmailController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public Usuario Get(string email)
        {
            Usuario u = _unit.UsuarioRepository.EnviarEmail(email);
            if(u != null)
            {
                _unit.Save();
            }
            return u;
        }
    }
}
