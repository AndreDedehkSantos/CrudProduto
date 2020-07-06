using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Bussiness;
using CrudProduto.Bussiness.Services;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Dal;
using CrudProduto.Models;
using CrudProduto.Models.ViewModels;
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


		public IActionResult Index()
		{
			return RedirectToAction("Index", "Produtoes");
		}

		[HttpGet]
		public IActionResult Create()
        {
			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LinhaProduto linha)
		{
			LinhaProduto linhaProduto = new LinhaProduto(linha.nome);
			LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
			ICollection<string> validacoes = new List<string>();
			validacoes = lpFachada.ValidarLinha(linha);
			if(validacoes.Count() == 0)
            {
				lpFachada.salvar(linhaProduto);
				return RedirectToAction("Index", "Home");
            }
            else
            {
				return View("Error", validacoes);
            }
			
		}
	}
}
