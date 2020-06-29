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
    public class LinhaProdutoesController : Controller
    {
        private readonly CrudProdutoContext _context;

        public LinhaProdutoesController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: LinhaProdutoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhaProduto.ToListAsync());
        }

        // GET: LinhaProdutoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProduto = await _context.LinhaProduto
                .FirstOrDefaultAsync(m => m.id == id);
            if (linhaProduto == null)
            {
                return NotFound();
            }

            return View(linhaProduto);
        }

        // GET: LinhaProdutoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinhaProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,id,descLog")] LinhaProduto linhaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaProduto);
        }

        // GET: LinhaProdutoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProduto = await _context.LinhaProduto.FindAsync(id);
            if (linhaProduto == null)
            {
                return NotFound();
            }
            return View(linhaProduto);
        }

        // POST: LinhaProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nome,id,descLog")] LinhaProduto linhaProduto)
        {
            if (id != linhaProduto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaProdutoExists(linhaProduto.id))
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
            return View(linhaProduto);
        }

        // GET: LinhaProdutoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProduto = await _context.LinhaProduto
                .FirstOrDefaultAsync(m => m.id == id);
            if (linhaProduto == null)
            {
                return NotFound();
            }

            return View(linhaProduto);
        }

        // POST: LinhaProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaProduto = await _context.LinhaProduto.FindAsync(id);
            _context.LinhaProduto.Remove(linhaProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaProdutoExists(int id)
        {
            return _context.LinhaProduto.Any(e => e.id == id);
        }
    }
}
