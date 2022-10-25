using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoX.Data;
using ProyectoX.Models;

namespace ProyectoX.Controllers
{
    [Authorize]
    public class FacturaComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaCompras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacturaCompra.Include(f => f.IdCotizacionCompraNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FacturaCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCompra = await _context.FacturaCompra
                .Include(f => f.IdCotizacionCompraNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaCompra == id);
            if (facturaCompra == null)
            {
                return NotFound();
            }

            return View(facturaCompra);
        }

        // GET: FacturaCompras/Create
        public IActionResult Create()
        {
            ViewData["IdCotizacionCompra"] = new SelectList(_context.CotizacionCompra, "IdCotizacionCompra", "IdCotizacionCompra");
            return View();
        }

        // POST: FacturaCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacturaCompra,Serie,NoFactura,IdCotizacionCompra,SubTotal,Descuento,Total,IdDevolucion,Estado,FechaActualizacion,FechaCreacion")] FacturaCompra facturaCompra)
        {
            if (ModelState.IsValid)
            {
                facturaCompra.FechaCreacion = DateTime.Now;
                _context.Add(facturaCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCotizacionCompra"] = new SelectList(_context.CotizacionCompra, "IdCotizacionCompra", "IdCotizacionCompra", facturaCompra.IdCotizacionCompra);
            return View(facturaCompra);
        }

        // GET: FacturaCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCompra = await _context.FacturaCompra.FindAsync(id);
            if (facturaCompra == null)
            {
                return NotFound();
            }
            ViewData["IdCotizacionCompra"] = new SelectList(_context.CotizacionCompra, "IdCotizacionCompra", "IdCotizacionCompra", facturaCompra.IdCotizacionCompra);
            return View(facturaCompra);
        }

        // POST: FacturaCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacturaCompra,Serie,NoFactura,IdCotizacionCompra,SubTotal,Descuento,Total,IdDevolucion,Estado,FechaActualizacion,FechaCreacion")] FacturaCompra facturaCompra)
        {
            if (id != facturaCompra.IdFacturaCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facturaCompra.FechaActualizacion = DateTime.Now;
                    _context.Update(facturaCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaCompraExists(facturaCompra.IdFacturaCompra))
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
            ViewData["IdCotizacionCompra"] = new SelectList(_context.CotizacionCompra, "IdCotizacionCompra", "IdCotizacionCompra", facturaCompra.IdCotizacionCompra);
            return View(facturaCompra);
        }

        // GET: FacturaCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCompra = await _context.FacturaCompra
                .Include(f => f.IdCotizacionCompraNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaCompra == id);
            if (facturaCompra == null)
            {
                return NotFound();
            }

            return View(facturaCompra);
        }

        // POST: FacturaCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaCompra = await _context.FacturaCompra.FindAsync(id);
            _context.FacturaCompra.Remove(facturaCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaCompraExists(int id)
        {
            return _context.FacturaCompra.Any(e => e.IdFacturaCompra == id);
        }
    }
}
