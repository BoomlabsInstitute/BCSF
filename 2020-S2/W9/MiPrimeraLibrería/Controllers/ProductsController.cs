using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiTiendita.Data;
using MiTiendita.Models;
using MiTiendita.Helpers;

namespace MiTiendita.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private MiPrimerServicio _miPrimerServicio;
        public ProductsController(ApplicationDbContext db, MiPrimerServicio __mps)
        {
            _context = db;
            _miPrimerServicio = __mps;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Producto.Include(p => p.Tienda);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Tienda)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producto == null)
            {
                return NotFound();
            }

            _miPrimerServicio.CalcularPrecio(producto, 12);
            return View(producto);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["TiendaID"] = new SelectList(_context.Tienda, "ID", "Title");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Cantidad,Imagen,Precio,TiendaID")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TiendaID"] = new SelectList(_context.Tienda, "ID", "ID", producto.TiendaID);
            return View(producto);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["TiendaID"] = new SelectList(_context.Tienda, "ID", "ID", producto.TiendaID);
            return View(producto);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Imagen,Cantidad,Precio,TiendaID")] Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ID))
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
            ViewData["TiendaID"] = new SelectList(_context.Tienda, "ID", "ID", producto.TiendaID);
            return View(producto);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Tienda)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.ID == id);
        }
    }
}
