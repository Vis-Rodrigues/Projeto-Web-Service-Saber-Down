using SDW.WebServiceJogo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public interface IGuardaRoupaRepository
    {
        void Cadastrar(GuardaRoupa guardaRoupa);
        void Atualizar(GuardaRoupa guardaRoupa);

        ICollection<GuardaRoupa> BuscarPorUsuario(int codigoUsuario);
        ICollection<GuardaRoupa> Listar();

    }
}
