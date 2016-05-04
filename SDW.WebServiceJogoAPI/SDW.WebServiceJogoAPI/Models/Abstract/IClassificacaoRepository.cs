using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IClassificacaoRepository
    {
        void Cadastrar(ClassificacaoVestuario classificacao);
        ICollection<ClassificacaoVestuario> Listar();
    }
}
