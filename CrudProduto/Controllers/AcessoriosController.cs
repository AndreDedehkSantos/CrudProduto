using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudProduto.Controllers
{
    public class AcessoriosController : Controller
    {
        private readonly CrudProdutoContext _context;

        public AcessoriosController(CrudProdutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Acessorio acessorio)
        {
            AcessorioFachada acessorioFachada = new AcessorioFachada(_context);
            acessorioFachada.salvar(acessorio);
            return RedirectToAction("Index", "Home");
        }
    }
}
