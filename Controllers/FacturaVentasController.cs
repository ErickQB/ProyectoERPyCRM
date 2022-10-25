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
    public class FacturaVentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaVentas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacturaVenta.Include(f => f.IdClienteNavigation).Include(f => f.IdCotizacionVentaNavigation).Include(f => f.IdVendedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FacturaVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaVenta = await _context.FacturaVenta
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdCotizacionVentaNavigation)
                .Include(f => f.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaVenta == id);
            if (facturaVenta == null)
            {
                return NotFound();
            }

            return View(facturaVenta);
        }

        // GET: FacturaVentas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido");
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo");
            return View();
        }

        // POST: FacturaVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacturaVenta,IdCotizacionVenta,IdVendedor,Fecha,IdCliente,DireccionFactura,DireccionEntrega,Correlativo,NitCliente,Iva,SubTotal,Descuento,Total,Estado,FechaCreacion,FechaActualizacion")] FacturaVenta facturaVenta)
        {
            if (ModelState.IsValid)
            {
                facturaVenta.FechaCreacion = DateTime.Now;
                _context.Add(facturaVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", facturaVenta.IdCliente);
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", facturaVenta.IdCotizacionVenta);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", facturaVenta.IdVendedor);
            return View(facturaVenta);
        }

        // GET: FacturaVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaVenta = await _context.FacturaVenta.FindAsync(id);
            if (facturaVenta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", facturaVenta.IdCliente);
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", facturaVenta.IdCotizacionVenta);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", facturaVenta.IdVendedor);
            return View(facturaVenta);
        }

        // POST: FacturaVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacturaVenta,IdCotizacionVenta,IdVendedor,Fecha,IdCliente,DireccionFactura,DireccionEntrega,Correlativo,NitCliente,Iva,SubTotal,Descuento,Total,Estado,FechaCreacion,FechaActualizacion")] FacturaVenta facturaVenta)
        {
            if (id != facturaVenta.IdFacturaVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facturaVenta.FechaActualizacion = DateTime.Now;
                    _context.Update(facturaVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaVentaExists(facturaVenta.IdFacturaVenta))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", facturaVenta.IdCliente);
            ViewData["IdCotizacionVenta"] = new SelectList(_context.CotizacionVenta, "IdCotizacionVenta", "EstadoCotizacion", facturaVenta.IdCotizacionVenta);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", facturaVenta.IdVendedor);
            return View(facturaVenta);
        }

        // GET: FacturaVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaVenta = await _context.FacturaVenta
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdCotizacionVentaNavigation)
                .Include(f => f.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaVenta == id);
            if (facturaVenta == null)
            {
                return NotFound();
            }

            return View(facturaVenta);
        }

        // POST: FacturaVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaVenta = await _context.FacturaVenta.FindAsync(id);
            _context.FacturaVenta.Remove(facturaVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaVentaExists(int id)
        {
            return _context.FacturaVenta.Any(e => e.IdFacturaVenta == id);
        }
    }
}
