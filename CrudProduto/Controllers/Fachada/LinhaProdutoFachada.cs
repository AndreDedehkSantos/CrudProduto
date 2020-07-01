using CrudProduto.Bussiness;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	public class LinhaProdutoFachada : IFachada
	{
		private readonly CrudProdutoContext _context;

		public LinhaProdutoFachada(CrudProdutoContext context)
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

		public void salvar(EntidadeDominio entidadeDominio)
		{
			LinhaProduto linhaProduto = (LinhaProduto)entidadeDominio;
			LinhaProdutoDal lpDal = new LinhaProdutoDal(_context);
			lpDal.Inserir(linhaProduto);
		}
	}
}
