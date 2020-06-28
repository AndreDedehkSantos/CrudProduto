using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;

namespace CrudProduto.Controllers
{
    public class AcessorioBasicosController : Controller
    {
        private readonly CrudProdutoContext _context;

        public AcessorioBasicosController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: AcessorioBasicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcessorioBasico.ToListAsync());
        }

        // GET: AcessorioBasicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioBasico = await _context.AcessorioBasico
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorioBasico == null)
            {
                return NotFound();
            }

            return View(acessorioBasico);
        }

        // GET: AcessorioBasicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcessorioBasicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,descricao,quantidade")] AcessorioBasico acessorioBasico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessorioBasico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessorioBasico);
        }

        // GET: AcessorioBasicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioBasico = await _context.AcessorioBasico.FindAsync(id);
            if (acessorioBasico == null)
            {
                return NotFound();
            }
            return View(acessorioBasico);
        }

        // POST: AcessorioBasicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,descricao,quantidade")] AcessorioBasico acessorioBasico)
        {
            if (id != acessorioBasico.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessorioBasico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessorioBasicoExists(acessorioBasico.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(acessorioBasico);
        }

        // GET: AcessorioBasicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioBasico = await _context.AcessorioBasico
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorioBasico == null)
            {
                return NotFound();
            }

            return View(acessorioBasico);
        }

        // POST: AcessorioBasicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessorioBasico = await _context.AcessorioBasico.FindAsync(id);
            _context.AcessorioBasico.Remove(acessorioBasico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessorioBasicoExists(int id)
        {
            return _context.AcessorioBasico.Any(e => e.id == id);
        }
    }
}
