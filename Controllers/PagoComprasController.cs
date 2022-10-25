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
    public class PagoComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PagoCompras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PagoCompra.Include(p => p.IdFacturaCompraNavigation).Include(p => p.IdTipoPagoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PagoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoCompra = await _context.PagoCompra
                .Include(p => p.IdFacturaCompraNavigation)
                .Include(p => p.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPagoCompra == id);
            if (pagoCompra == null)
            {
                return NotFound();
            }

            return View(pagoCompra);
        }

        // GET: PagoCompras/Create
        public IActionResult Create()
        {
            ViewData["IdFacturaCompra"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie");
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre");
            return View();
        }

        // POST: PagoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagoCompra,FechaPago,IdFacturaCompra,Total,Estado,IdTipoPago,FechaCreacion,FechaActualizacion")] PagoCompra pagoCompra)
        {
            if (ModelState.IsValid)
            {
                pagoCompra.FechaCreacion = DateTime.Now;
                _context.Add(pagoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFacturaCompra"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", pagoCompra.IdFacturaCompra);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", pagoCompra.IdTipoPago);
            return View(pagoCompra);
        }

        // GET: PagoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoCompra = await _context.PagoCompra.FindAsync(id);
            if (pagoCompra == null)
            {
                return NotFound();
            }
            ViewData["IdFacturaCompra"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", pagoCompra.IdFacturaCompra);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", pagoCompra.IdTipoPago);
            return View(pagoCompra);
        }

        // POST: PagoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagoCompra,FechaPago,IdFacturaCompra,Total,Estado,IdTipoPago,FechaCreacion,FechaActualizacion")] PagoCompra pagoCompra)
        {
            if (id != pagoCompra.IdPagoCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pagoCompra.FechaActualizacion = DateTime.Now;
                    _context.Update(pagoCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoCompraExists(pagoCompra.IdPagoCompra))
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
            ViewData["IdFacturaCompra"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", pagoCompra.IdFacturaCompra);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", pagoCompra.IdTipoPago);
            return View(pagoCompra);
        }

        // GET: PagoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoCompra = await _context.PagoCompra
                .Include(p => p.IdFacturaCompraNavigation)
                .Include(p => p.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPagoCompra == id);
            if (pagoCompra == null)
            {
                return NotFound();
            }

            return View(pagoCompra);
        }

        // POST: PagoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagoCompra = await _context.PagoCompra.FindAsync(id);
            _context.PagoCompra.Remove(pagoCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoCompraExists(int id)
        {
            return _context.PagoCompra.Any(e => e.IdPagoCompra == id);
        }
    }
}
