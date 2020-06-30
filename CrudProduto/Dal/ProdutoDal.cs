using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
	public class ProdutoDal
	{
		private readonly CrudProdutoContext _context;

		public ProdutoDal(CrudProdutoContext context)
		{
			_context = context;
		}

		public List<Produto> Listar()
		{
			return _context.Produto.ToList();
		}

		public void Inserir(LinhaProduto obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}

	}
}
