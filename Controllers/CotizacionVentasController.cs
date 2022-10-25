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
    public class CotizacionVentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private FacturaVenta facturaVenta;

        public CotizacionVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CotizacionVentas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CotizacionVenta.Include(c => c.IdClienteNavigation).Include(c => c.IdVendedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CotizacionVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionVenta = await _context.CotizacionVenta
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacionVenta == id);
            if (cotizacionVenta == null)
            {
                return NotFound();
            }

            return View(cotizacionVenta);
        }

        // GET: CotizacionVentas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo");
            return View();
        }

        // POST: CotizacionVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacionVenta,Fecha,EstadoCotizacion,IdVendedor,IdCliente,SubTotal,Descuento,Total,Estado,FechaCreacion,FechaActualizacion")] CotizacionVenta cotizacionVenta)
        {
            if (ModelState.IsValid)
            {
                cotizacionVenta.FechaCreacion = DateTime.Now;
                _context.Add(cotizacionVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", cotizacionVenta.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", cotizacionVenta.IdVendedor);
            return View(cotizacionVenta);
        }

        // GET: CotizacionVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionVenta = await _context.CotizacionVenta.FindAsync(id);
            if (cotizacionVenta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", cotizacionVenta.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", cotizacionVenta.IdVendedor);
            return View(cotizacionVenta);
        }

        // POST: CotizacionVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCotizacionVenta,Fecha,EstadoCotizacion,IdVendedor,IdCliente,SubTotal,Descuento,Total,Estado,FechaCreacion,FechaActualizacion")] CotizacionVenta cotizacionVenta)
        {
            if (id != cotizacionVenta.IdCotizacionVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cotizacionVenta.FechaActualizacion = DateTime.Now;
                    _context.Update(cotizacionVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionVentaExists(cotizacionVenta.IdCotizacionVenta))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", cotizacionVenta.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", cotizacionVenta.IdVendedor);
            return View(cotizacionVenta);
        }

        // GET: CotizacionVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionVenta = await _context.CotizacionVenta
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacionVenta == id);
            if (cotizacionVenta == null)
            {
                return NotFound();
            }

            return View(cotizacionVenta);
        }

        // POST: CotizacionVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacionVenta = await _context.CotizacionVenta.FindAsync(id);
            _context.CotizacionVenta.Remove(cotizacionVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionVentaExists(int id)
        {
            return _context.CotizacionVenta.Any(e => e.IdCotizacionVenta == id);
        }

        // GET: CotizacionDetalleVentas/Index/5
        public async Task<IActionResult> CrearLineas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionVenta = await _context.CotizacionVenta.FindAsync(id);
            if (cotizacionVenta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Apellido", cotizacionVenta.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", cotizacionVenta.IdVendedor);
            return View(cotizacionVenta);
        }

        public async Task<IActionResult> Factura(int? id_cotizacion)
        {
            FacturaVenta fac = new FacturaVenta();

            var cotizacionVenta = await _context.CotizacionVenta.Where(x => x.IdCotizacionVenta == id_cotizacion).ToListAsync();
            foreach(var item in cotizacionVenta){
                fac.IdCotizacionVenta = item.IdCotizacionVenta;
                fac.IdVendedor = item.IdVendedor;
                fac.Fecha = item.Fecha;
                fac.IdCliente = item.IdCliente;
                fac.Correlativo = "P";
                fac.DireccionEntrega = "P";
                fac.DireccionFactura = "P";
                fac.NitCliente = "P";
            }
            fac.FechaCreacion = DateTime.Now;
            _context.Add(fac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(await applicationDbContext.ToListAsync());
        }

    }
}
