using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Models;
using CrudProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudProduto.Controllers
{

    public class AcessoriosOpcController : Controller
    {

        private readonly CrudProdutoContext _context;

        public AcessoriosOpcController(CrudProdutoContext context)
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
            ProdutoFachada pFachada = new ProdutoFachada(_context);
            ICollection<Produto> listaProduto = new List<Produto>();
            ICollection<EntidadeDominio> listaEnt = pFachada.Listar();
            foreach (EntidadeDominio item in listaEnt)
            {
                listaProduto.Add((Produto)item);
            }
            var aVM = new AcessorioViewModel { produtos = listaProduto };
            return View(aVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AcessorioViewModel acessorioVM)
        {
            AcessorioOpcionalFachada acessorioFachada = new AcessorioOpcionalFachada(_context);
            ICollection<string> validacoes = new List<string>();
            validacoes = acessorioFachada.ValidarAcessorioOpcional(acessorioVM.acessorioO);
            if (validacoes.Count() == 0)
            {
                acessorioFachada.salvar(acessorioVM.acessorioO);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error", validacoes);
            }
        }
    }
}
