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
    public class CotizacionDetalleVentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public CotizacionDetalleVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CotizacionDetalleVentas
        public async Task<IActionResult> Index(int? id_cotizacion)
        {
            var applicationDbContext = _context.CotizacionDetalleVenta.Include(c => c.IdCotizacionVentaNavigation).Include(c => c.IdProductoNavigation);
            if (id_cotizacion == null)
            {
                return NotFound();
            }
            var cotizacionDetalleVenta = await _context.CotizacionDetalleVenta.Where(x => x.IdCotizacionVenta == id_cotizacion).ToListAsync();
            if (cotizacionDetalleVenta == null)
            {
                return NotFound();
            }
            //ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", cotizacionDetalleVenta);
            //ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacionDetalleVenta);
            //return View(cotizacionDetalleVenta);
            ViewData["IdCotizacionVenta"] = id_cotizacion;
            return View(cotizacionDetalleVenta);
        }

        // GET: CotizacionDetalleVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionDetalleVenta = await _context.CotizacionDetalleVenta
                .Include(c => c.IdCotizacionVentaNavigation)
                .Include(c => c.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacionDetalleVenta == id);
            if (cotizacionDetalleVenta == null)
            {
                return NotFound();
            }

            return View(cotizacionDetalleVenta);
        }

        // GET: CotizacionDetalleVentas/Create
        public IActionResult Create(int? id_cotizacion)
        {
            //ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "IdCotizacionVenta");
             ViewData["IdCotizacionVenta"] = id_cotizacion.Value;
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: CotizacionDetalleVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacionDetalleVenta,IdCotizacionVenta,Cantidad,IdProducto,PrecioUnitario,SubTotal,FechaCreacion,FechaActualizacion,Estado")] CotizacionDetalleVenta cotizacionDetalleVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacionDetalleVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id_cotizacion = cotizacionDetalleVenta.IdCotizacionVenta});
            }
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", cotizacionDetalleVenta.IdCotizacionVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacionDetalleVenta.IdProducto);
            return View(cotizacionDetalleVenta);
        }

        // GET: CotizacionDetalleVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionDetalleVenta = await _context.CotizacionDetalleVenta.FindAsync(id);
            if (cotizacionDetalleVenta == null)
            {
                return NotFound();
            }
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", cotizacionDetalleVenta.IdCotizacionVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacionDetalleVenta.IdProducto);
            return View(cotizacionDetalleVenta);
        }

        // POST: CotizacionDetalleVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCotizacionDetalleVenta,IdCotizacionVenta,Cantidad,IdProducto,PrecioUnitario,SubTotal,FechaCreacion,FechaActualizacion,Estado")] CotizacionDetalleVenta cotizacionDetalleVenta)
        {
            if (id != cotizacionDetalleVenta.IdCotizacionDetalleVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacionDetalleVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionDetalleVentaExists(cotizacionDetalleVenta.IdCotizacionDetalleVenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id_cotizacion = cotizacionDetalleVenta.IdCotizacionVenta });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", cotizacionDetalleVenta.IdCotizacionVenta);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacionDetalleVenta.IdProducto);
            return View(cotizacionDetalleVenta);
        }

        // GET: CotizacionDetalleVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionDetalleVenta = await _context.CotizacionDetalleVenta
                .Include(c => c.IdCotizacionVentaNavigation)
                .Include(c => c.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacionDetalleVenta == id);
            if (cotizacionDetalleVenta == null)
            {
                return NotFound();
            }

            return View(cotizacionDetalleVenta);
        }

        // POST: CotizacionDetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacionDetalleVenta = await _context.CotizacionDetalleVenta.FindAsync(id);
            int res = cotizacionDetalleVenta.IdCotizacionVenta;
            _context.CotizacionDetalleVenta.Remove(cotizacionDetalleVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id_cotizacion = res });
            //return RedirectToAction(nameof(Index));
        }

        private bool CotizacionDetalleVentaExists(int id)
        {
            return _context.CotizacionDetalleVenta.Any(e => e.IdCotizacionDetalleVenta == id);
        }
    }
}
