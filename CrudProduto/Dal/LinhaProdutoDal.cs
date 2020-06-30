using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness.Services
{
	public class LinhaProdutoDal
	{
		private readonly CrudProdutoContext _context;
		

		public LinhaProdutoDal(CrudProdutoContext context)
		{
			_context = context;
		}

		public List<LinhaProduto> Listar()
		{
			return _context.LinhaProduto.ToList();
		}

		public void Inserir(LinhaProduto obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}
	}
}
