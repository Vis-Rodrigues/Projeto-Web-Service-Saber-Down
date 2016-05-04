using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.Contexts;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private JogoContext _context;

        public CategoriaRepository(JogoContext context)
        {
            _context = context;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public ICollection<Categoria> Listar()
        {
            return _context.Categorias.ToList();
        }
    }
}