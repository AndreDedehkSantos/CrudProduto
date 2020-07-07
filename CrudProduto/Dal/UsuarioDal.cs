using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class UsuarioDal
    {
        private readonly CrudProdutoContext _context;

        public UsuarioDal(CrudProdutoContext context)
        {
            _context = context;
        }
        public void salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
