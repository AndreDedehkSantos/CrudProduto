using CrudProduto.Dal;
using CrudProduto.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class AcessorioFachada : IFachada
    {

        private readonly CrudProdutoContext _context;

        public AcessorioFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public void alterar(EntidadeDominio entidadeDominio)
        {
            
        }

        public void inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EntidadeDominio> Listar()
        {
            AcessorioDal lpDal = new AcessorioDal(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            listaEnt = lpDal.Listar();
            return listaEnt;
        }

        public void salvar(EntidadeDominio entidadeDominio)
        {
            AcessorioDal aDal = new AcessorioDal(_context);
            aDal.Salvar(entidadeDominio);
        }
    }
}
