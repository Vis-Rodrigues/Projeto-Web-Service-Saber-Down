using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IAlternativaComPreRepository
    {
        void Cadastrar(AlternativaComPreMon alternativa);
        IList<AlternativaComPreMon> Listar();
        ICollection<AlternativaComPreMon> BuscarPorQuestao(int questaoId);
    }
}
