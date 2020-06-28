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
    public class AcessorioOpcionaisController : Controller
    {
        private readonly CrudProdutoContext _context;

        public AcessorioOpcionaisController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: AcessorioOpcionals
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcessorioOpcional.ToListAsync());
        }

        // GET: AcessorioOpcionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioOpcional = await _context.AcessorioOpcional
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorioOpcional == null)
            {
                return NotFound();
            }

            return View(acessorioOpcional);
        }

        // GET: AcessorioOpcionals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcessorioOpcionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,descricao,quantidade")] AcessorioOpcional acessorioOpcional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessorioOpcional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessorioOpcional);
        }

        // GET: AcessorioOpcionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioOpcional = await _context.AcessorioOpcional.FindAsync(id);
            if (acessorioOpcional == null)
            {
                return NotFound();
            }
            return View(acessorioOpcional);
        }

        // POST: AcessorioOpcionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,descricao,quantidade")] AcessorioOpcional acessorioOpcional)
        {
            if (id != acessorioOpcional.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessorioOpcional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessorioOpcionalExists(acessorioOpcional.id))
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
            return View(acessorioOpcional);
        }

        // GET: AcessorioOpcionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorioOpcional = await _context.AcessorioOpcional
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorioOpcional == null)
            {
                return NotFound();
            }

            return View(acessorioOpcional);
        }

        // POST: AcessorioOpcionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessorioOpcional = await _context.AcessorioOpcional.FindAsync(id);
            _context.AcessorioOpcional.Remove(acessorioOpcional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessorioOpcionalExists(int id)
        {
            return _context.AcessorioOpcional.Any(e => e.id == id);
        }
    }
}
