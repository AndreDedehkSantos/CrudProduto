using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace CrudProduto.Controllers
{
	public class LinhaProdutoesController : Controller
	{
		private readonly LinhaProdutoDal _linhaProdutoDal;

		public LinhaProdutoesController(LinhaProdutoDal linhaProdutoService)
		{
			_linhaProdutoDal = linhaProdutoService;
		}

		public IActionResult Index()
		{
			var list = _linhaProdutoDal.Listar();
			return View(list);
		}

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LinhaProduto linhaProduto)
		{
			_linhaProdutoDal.Inserir(linhaProduto);
			return RedirectToAction("_Layout");
		}
	}
}
