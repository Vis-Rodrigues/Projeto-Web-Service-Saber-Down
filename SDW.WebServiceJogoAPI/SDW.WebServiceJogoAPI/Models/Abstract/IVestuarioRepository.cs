using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
   public interface IVestuarioRepository
    {
        void Cadastrar(Vestuario vestuario);

        ICollection<Vestuario> Listar();

        ICollection<Vestuario> BuscarPorClassificacao(int classificacaoId);
    }
}
