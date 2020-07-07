using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models.ViewModels;
using CrudProduto.Controllers.Fachada;
using System.Numerics;

namespace CrudProduto.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly CrudProdutoContext _context;

        public ProdutoesController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {

            ProdutoFachada pFachada = new ProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            listaEnt = pFachada.Listar();
            ICollection<Produto> lista = new List<Produto>();
            foreach(EntidadeDominio item in listaEnt)
            {
                lista.Add((Produto)item);
            }
            return View(lista);
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            ProdutoFachada produtoFachada = new ProdutoFachada(_context);
            Produto p = produtoFachada.Consultar(id);
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            LinhaProduto lp = lpFachada.Consultar(p.linhaProdutoid);
            AcessorioOpcionalFachada acessorioOFachada = new AcessorioOpcionalFachada(_context);
            AcessorioBasicoFachada acessorioBFachada = new AcessorioBasicoFachada(_context);
            ICollection<AcessorioOpcional> listaAcessoriosO = new List<AcessorioOpcional>();
            listaAcessoriosO = acessorioOFachada.Consultar(p.id);
            ICollection<AcessorioBasico> listaAcessoriosB = new List<AcessorioBasico>();
            listaAcessoriosB = acessorioBFachada.Consultar(p.linhaProdutoid);
            ProdutoViewModel pVM = new ProdutoViewModel { produto = p, acessoriosO = listaAcessoriosO, acessoriosB = listaAcessoriosB, linha = lp };
            if (p == null)
            {
                return NotFound();
            }

            return View(pVM);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<LinhaProduto> lista = new List<LinhaProduto>();
            listaEnt = lpFachada.Listar();
            foreach(EntidadeDominio item in listaEnt)
            {
                lista.Add((LinhaProduto)item);
            }
            var linhas = lista;
            var viewModel = new ProdutoViewModel{ lp = linhas};
            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.status = true;
                ProdutoFachada produtoFachada = new ProdutoFachada(_context);
                FichaTecnicaFachada fichaFachada = new FichaTecnicaFachada(_context);
                ICollection<string> validacoes = produtoFachada.ValidarProduto(produto);
                ICollection<string> validacoesFicha = fichaFachada.ValidarFicha(produto.fichaTecnica);
                foreach (string item in validacoesFicha)
                {
                    validacoes.Add(item);
                }
                if (validacoes.Count() == 0)
                {
                    
                    produtoFachada.salvar(produto);
                }
                else
                {
                    return View("Error", validacoes);
                }

                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<LinhaProduto> lista = new List<LinhaProduto>();
            listaEnt = lpFachada.Listar();
            foreach (EntidadeDominio item in listaEnt)
            {
                lista.Add((LinhaProduto)item);
            }
            var linhas = lista;

            ProdutoFachada produtoFachada = new ProdutoFachada(_context);
            int ID = (int)id;
            var p = produtoFachada.Consultar(ID);
            if (p == null)
            {
                return NotFound();
            }
            ProdutoViewModel pVM = new ProdutoViewModel { produto = p,  lp = linhas};
            return View(pVM);
        }

   
       public IActionResult EditFT(Produto p)
        {
            return RedirectToAction("Edit", "FichaTecnicas", p);
        }

    }
}
