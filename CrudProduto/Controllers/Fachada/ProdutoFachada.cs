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

		public void inativar(EntidadeDominio EntidadeDominio)
		{
			
		}

		public void listar(EntidadeDominio EntidadeDominio)
		{
			
		}

		public void salvar(EntidadeDominio EntidadeDominio)
		{
			Produto produto = (Produto)EntidadeDominio;
			ProdutoDal pDAL = new ProdutoDal(_context);
			pDAL.Inserir(produto);
		}
	}
}
