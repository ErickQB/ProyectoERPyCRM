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
    public class FacturaDetalleVentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetalleVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaDetalleVentas
        public async Task<IActionResult> Index(int? id_Factura)
        {
            var applicationDbContext = _context.FacturaDetalleVenta.Include(f => f.IdFacturaVentaNavigation).Include(f => f.IdProductoNavigation).Where(f => f.IdFacturaVenta == id_Factura);
            //var facturaDetalle = await _context.FacturaDetalleVenta.Where(x => x.IdFacturaVenta == id_Factura).ToListAsync();
            return View(await applicationDbContext.ToListAsync());
            //return View(facturaDetalle);
        }

        // GET: FacturaDetalleVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleVenta = await _context.FacturaDetalleVenta
                .Include(f => f.IdFacturaVentaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDetalleVenta == id);
            if (facturaDetalleVenta == null)
            {
                return NotFound();
            }

            return View(facturaDetalleVenta);
        }

        // GET: FacturaDetalleVentas/Create
        public IActionResult Create()
        {
            ViewData["IdFacturaVenta"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: FacturaDetalleVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacturaDetalleVenta,IdFacturaVenta,Cantidad,IdProducto,PrecioUnitario,SubTotal,FechaCreacion,FechaActualizacion,Estado")] FacturaDetalleVenta facturaDetalleVenta)
        {
            if (ModelState.IsValid)
            {
                facturaDetalleVenta.FechaCreacion = DateTime.Now;
                _context.Add(facturaDetalleVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFacturaVenta"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", facturaDetalleVenta.IdFacturaVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleVenta.IdProducto);
            return View(facturaDetalleVenta);
        }

        // GET: FacturaDetalleVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleVenta = await _context.FacturaDetalleVenta.FindAsync(id);
            if (facturaDetalleVenta == null)
            {
                return NotFound();
            }
            ViewData["IdFacturaVenta"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", facturaDetalleVenta.IdFacturaVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleVenta.IdProducto);
            return View(facturaDetalleVenta);
        }

        // POST: FacturaDetalleVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacturaDetalleVenta,IdFacturaVenta,Cantidad,IdProducto,PrecioUnitario,SubTotal,FechaCreacion,FechaActualizacion,Estado")] FacturaDetalleVenta facturaDetalleVenta)
        {
            if (id != facturaDetalleVenta.IdFacturaDetalleVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facturaDetalleVenta.FechaActualizacion = DateTime.Now;
                    _context.Update(facturaDetalleVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetalleVentaExists(facturaDetalleVenta.IdFacturaDetalleVenta))
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
            ViewData["IdFacturaVenta"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", facturaDetalleVenta.IdFacturaVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleVenta.IdProducto);
            return View(facturaDetalleVenta);
        }

        // GET: FacturaDetalleVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleVenta = await _context.FacturaDetalleVenta
                .Include(f => f.IdFacturaVentaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDetalleVenta == id);
            if (facturaDetalleVenta == null)
            {
                return NotFound();
            }

            return View(facturaDetalleVenta);
        }

        // POST: FacturaDetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDetalleVenta = await _context.FacturaDetalleVenta.FindAsync(id);
            _context.FacturaDetalleVenta.Remove(facturaDetalleVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleVentaExists(int id)
        {
            return _context.FacturaDetalleVenta.Any(e => e.IdFacturaDetalleVenta == id);
        }
    }
}
