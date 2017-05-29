using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IPontuacaoRepository
    {
        void Cadastrar(Pontuacao pontuacao);
        void Atualizar(Pontuacao pontuacao);
        ICollection<Pontuacao> BuscarPorUsuario(int id);
        ICollection<Pontuacao> Listar();
        void Deletar(int codigo);
    }
}
