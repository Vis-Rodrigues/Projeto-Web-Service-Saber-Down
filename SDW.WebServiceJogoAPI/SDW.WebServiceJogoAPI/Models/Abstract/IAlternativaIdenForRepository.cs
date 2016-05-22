using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IAlternativaIdenForRepository
    {
        void Cadastrar(AlternativaIdenForme alternativa);
        ICollection<AlternativaIdenForme> BuscarPorQuestao(int questaoId);
        ICollection<AlternativaIdenForme> Listar();
        void Deletar(int codigo);
        AlternativaIdenForme BuscarPorCodigo(int id);
    }
}
