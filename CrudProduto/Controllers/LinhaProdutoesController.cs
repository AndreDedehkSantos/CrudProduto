using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Bussiness.Services;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace CrudProduto.Controllers
{
	public class LinhaProdutoesController : Controller
	{
		private readonly CrudProdutoContext _context;

		public LinhaProdutoesController(CrudProdutoContext context)
		{
			_context = context;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LinhaProduto linhaProduto)
		{
			LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
			return RedirectToAction("Create", "Produtoes");
		}
	}
}
