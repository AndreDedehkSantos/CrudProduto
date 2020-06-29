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
    public class AcessoriosController : Controller
    {
        private readonly CrudProdutoContext _context;

        public AcessoriosController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: Acessorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acessorio.ToListAsync());
        }

        // GET: Acessorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorio == null)
            {
                return NotFound();
            }

            return View(acessorio);
        }

        // GET: Acessorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acessorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,descricao,quantidade,id,descLog")] Acessorio acessorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessorio);
        }

        // GET: Acessorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio.FindAsync(id);
            if (acessorio == null)
            {
                return NotFound();
            }
            return View(acessorio);
        }

        // POST: Acessorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nome,descricao,quantidade,id,descLog")] Acessorio acessorio)
        {
            if (id != acessorio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessorioExists(acessorio.id))
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
            return View(acessorio);
        }

        // GET: Acessorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessorio == null)
            {
                return NotFound();
            }

            return View(acessorio);
        }

        // POST: Acessorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessorio = await _context.Acessorio.FindAsync(id);
            _context.Acessorio.Remove(acessorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessorioExists(int id)
        {
            return _context.Acessorio.Any(e => e.id == id);
        }
    }
}
