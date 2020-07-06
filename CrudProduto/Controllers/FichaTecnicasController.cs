using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Dal;

namespace CrudProduto.Controllers
{
    public class FichaTecnicasController : Controller
    {
        private readonly CrudProdutoContext _context;

        public FichaTecnicasController(CrudProdutoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Edit(Produto p)
        {
            var fichaTecnica = await _context.FichaTecnica.FindAsync(p.id);
            if (fichaTecnica == null)
            {
                return NotFound();
            }
            return View(fichaTecnica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FichaTecnica fichaTecnica)
        {
            if (id != fichaTecnica.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try 
                {
                    FichaTecnicaFachada fichaFachada = new FichaTecnicaFachada(_context);
                    ICollection<string> validacoes = new List<string>();
                    validacoes = fichaFachada.ValidarFicha(fichaTecnica);
                    if(validacoes.Count() == 0)
                    {
                        fichaFachada.alterar(fichaTecnica);
                    }
                    else
                    {
                        return View("Error");
                    }
                    _context.Update(fichaTecnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaTecnicaExists(fichaTecnica.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Produtoes");
            }
            return View(fichaTecnica);
        }

        private bool FichaTecnicaExists(int id)
        {
            return _context.FichaTecnica.Any(e => e.id == id);
        }
    }
}
