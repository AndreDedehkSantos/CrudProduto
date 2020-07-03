using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	public class ProdutoFachada : IFachada
	{
		private readonly CrudProdutoContext _context;

		public ProdutoFachada(CrudProdutoContext context)
		{
			_context = context;
		}

		public void alterar(EntidadeDominio EntidadeDominio)
		{
			
		}

		public void inativar(int id)
		{
			
		}

        public ICollection<EntidadeDominio> Listar()
        {
			ProdutoDal pDAL = new ProdutoDal(_context);
			ICollection<EntidadeDominio> lista = new List<EntidadeDominio>();
			lista = pDAL.Listar();
			return lista;
        }

        public void salvar(EntidadeDominio entidadeDominio)
		{
			ProdutoDal pDAL = new ProdutoDal(_context);
			pDAL.Salvar(entidadeDominio);
		}
	}
}
