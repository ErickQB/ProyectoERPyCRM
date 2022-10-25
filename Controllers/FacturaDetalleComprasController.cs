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
    public class FacturaDetalleComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetalleComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaDetalleCompras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacturaDetalleCompra.Include(f => f.IdFacturaNavigation).Include(f => f.IdProductoNavigation).Include(f => f.IdTipoConsumoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FacturaDetalleCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleCompra = await _context.FacturaDetalleCompra
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .Include(f => f.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDetalleCompra == id);
            if (facturaDetalleCompra == null)
            {
                return NotFound();
            }

            return View(facturaDetalleCompra);
        }

        // GET: FacturaDetalleCompras/Create
        public IActionResult Create()
        {
            ViewData["IdFactura"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumo, "IdTipoConsumo", "Nombre");
            return View();
        }

        // POST: FacturaDetalleCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacturaDetalleCompra,IdFactura,IdTipoConsumo,IdProducto,Descripcion,Cantidad,SubTotal,CargarInventario,Estado,FechaCreacion,FechaActualizacion")] FacturaDetalleCompra facturaDetalleCompra)
        {
            if (ModelState.IsValid)
            {
                facturaDetalleCompra.FechaCreacion = DateTime.Now;
                _context.Add(facturaDetalleCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFactura"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", facturaDetalleCompra.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleCompra.IdProducto);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumo, "IdTipoConsumo", "Nombre", facturaDetalleCompra.IdTipoConsumo);
            return View(facturaDetalleCompra);
        }

        // GET: FacturaDetalleCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleCompra = await _context.FacturaDetalleCompra.FindAsync(id);
            if (facturaDetalleCompra == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", facturaDetalleCompra.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleCompra.IdProducto);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumo, "IdTipoConsumo", "Nombre", facturaDetalleCompra.IdTipoConsumo);
            return View(facturaDetalleCompra);
        }

        // POST: FacturaDetalleCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacturaDetalleCompra,IdFactura,IdTipoConsumo,IdProducto,Descripcion,Cantidad,SubTotal,CargarInventario,Estado,FechaCreacion,FechaActualizacion")] FacturaDetalleCompra facturaDetalleCompra)
        {
            if (id != facturaDetalleCompra.IdFacturaDetalleCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facturaDetalleCompra.FechaActualizacion = DateTime.Now;
                    _context.Update(facturaDetalleCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetalleCompraExists(facturaDetalleCompra.IdFacturaDetalleCompra))
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
            ViewData["IdFactura"] = new SelectList(_context.FacturaCompra, "IdFacturaCompra", "Serie", facturaDetalleCompra.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", facturaDetalleCompra.IdProducto);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumo, "IdTipoConsumo", "Nombre", facturaDetalleCompra.IdTipoConsumo);
            return View(facturaDetalleCompra);
        }

        // GET: FacturaDetalleCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalleCompra = await _context.FacturaDetalleCompra
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .Include(f => f.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDetalleCompra == id);
            if (facturaDetalleCompra == null)
            {
                return NotFound();
            }

            return View(facturaDetalleCompra);
        }

        // POST: FacturaDetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDetalleCompra = await _context.FacturaDetalleCompra.FindAsync(id);
            _context.FacturaDetalleCompra.Remove(facturaDetalleCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleCompraExists(int id)
        {
            return _context.FacturaDetalleCompra.Any(e => e.IdFacturaDetalleCompra == id);
        }
    }
}
