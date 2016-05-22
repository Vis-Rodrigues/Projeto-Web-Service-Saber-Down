using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IQuestaoRepository
    {
        void Cadastrar(Questao questao);
        ICollection<Questao> BuscarPorCategoria(int id);
        ICollection<Questao> Listar();
        void Deletar(int codigo);
    }
}
