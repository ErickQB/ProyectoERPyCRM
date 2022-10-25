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
    public class ProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Producto.Include(p => p.IdProveedorNavigation).Include(p => p.IdTipoClienteANavigation).Include(p => p.IdTipoClienteBNavigation).Include(p => p.IdTipoClienteCNavigation).Include(p => p.IdTipoClienteDNavigation).Include(p => p.IdTipoClienteENavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdTipoClienteANavigation)
                .Include(p => p.IdTipoClienteBNavigation)
                .Include(p => p.IdTipoClienteCNavigation)
                .Include(p => p.IdTipoClienteDNavigation)
                .Include(p => p.IdTipoClienteENavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor");
            ViewData["IdTipoClienteA"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo");
            ViewData["IdTipoClienteB"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo");
            ViewData["IdTipoClienteC"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo");
            ViewData["IdTipoClienteD"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo");
            ViewData["IdTipoClienteE"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,Nombre,Descripcion,Tipo,Cantidad,PrecioCompra,PrecioVentaPublicoGeneral,IdTipoClienteA,PrecioClienteA,IdTipoClienteB,PrecioClienteB,IdTipoClienteC,PrecioClienteC,IdTipoClienteD,PrecioClienteD,IdTipoClienteE,PrecioClienteE,IdProveedor,FotoProducto,Estado,FechaCreacion,FechaActualizacion")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.FechaCreacion = DateTime.Now;
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor", producto.IdProveedor);
            ViewData["IdTipoClienteA"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteA);
            ViewData["IdTipoClienteB"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteB);
            ViewData["IdTipoClienteC"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteC);
            ViewData["IdTipoClienteD"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteD);
            ViewData["IdTipoClienteE"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteE);
            return View(producto);
        }

        // GET: Productoes/Edit/5
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "ClasificacionProveedor", producto.IdProveedor);
            ViewData["IdTipoClienteA"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteA);
            ViewData["IdTipoClienteB"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteB);
            ViewData["IdTipoClienteC"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteC);
            ViewData["IdTipoClienteD"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteD);
            ViewData["IdTipoClienteE"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteE);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Nombre,Descripcion,Tipo,Cantidad,PrecioCompra,PrecioVentaPublicoGeneral,IdTipoClienteA,PrecioClienteA,IdTipoClienteB,PrecioClienteB,IdTipoClienteC,PrecioClienteC,IdTipoClienteD,PrecioClienteD,IdTipoClienteE,PrecioClienteE,IdProveedor,FotoProducto,Estado,FechaCreacion,FechaActualizacion")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    producto.FechaActualizacion = DateTime.Now;
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "ClasificacionProveedor", producto.IdProveedor);
            ViewData["IdTipoClienteA"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteA);
            ViewData["IdTipoClienteB"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteB);
            ViewData["IdTipoClienteC"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteC);
            ViewData["IdTipoClienteD"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteD);
            ViewData["IdTipoClienteE"] = new SelectList(_context.TipoCliente, "IdTipoCliente", "Codigo", producto.IdTipoClienteE);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdTipoClienteANavigation)
                .Include(p => p.IdTipoClienteBNavigation)
                .Include(p => p.IdTipoClienteCNavigation)
                .Include(p => p.IdTipoClienteDNavigation)
                .Include(p => p.IdTipoClienteENavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
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
            return _context.Producto.Any(e => e.IdProducto == id);
        }
    }
}
