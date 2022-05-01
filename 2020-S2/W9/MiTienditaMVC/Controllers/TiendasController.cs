using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiTiendita.Data;
using MiTiendita.Models;

namespace MiTiendita.Controllers
{
    public class TiendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tiendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tienda.ToListAsync());
        }

        // GET: Tiendas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // GET: Tiendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Balance")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienda);
        }

        // GET: Tiendas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return View(tienda);
        }

        // POST: Tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Title,Balance")] Tienda tienda)
        {
            if (id != tienda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaExists(tienda.ID))
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
            return View(tienda);
        }

        // GET: Tiendas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tienda = await _context.Tienda.FindAsync(id);
            _context.Tienda.Remove(tienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaExists(string id)
        {
            return _context.Tienda.Any(e => e.ID == id);
        }
    }
}
