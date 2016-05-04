using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IQuestaoUsuarioRepository
    {
        void Cadastrar(QuestaoUsuario questaoUsuario);
        ICollection<QuestaoUsuario> BuscarPorUsuario(int usuarioId);
        ICollection<QuestaoUsuario> Listar();
    }
}
