using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Bussiness.Services;
using CrudProduto.Controllers.Fachada;
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

		[HttpGet]
		public IActionResult Create()
        {
			AcessorioFachada aFachada = new AcessorioFachada(_context);
			ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
			ICollection<Acessorio> lista = new List<Acessorio>();
			listaEnt = aFachada.Listar();
			foreach (EntidadeDominio item in listaEnt)
			{
				lista.Add((Acessorio)item);
			}
			ICollection<Acessorio> acessorios = lista;
			var viewModel = new LinhaProdutoViewModel { acessorios = acessorios};
			return View(viewModel);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LinhaProdutoViewModel linha)
		{
			LinhaProduto linhaProduto = new LinhaProduto(linha.linhaProduto.nome, linha.acessorios);
			LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
			lpFachada.salvar(linhaProduto);
			return RedirectToAction("Index", "Home");
		}
	}
}
