using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoX.Data;
using ProyectoX.Models;

namespace ProyectoX.Controllers
{
    public class TiendaSucursalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendaSucursalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiendaSucursals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TiendaSucursal.Include(t => t.IdTiendaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TiendaSucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendaSucursal = await _context.TiendaSucursal
                .Include(t => t.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdTiendaSucursal == id);
            if (tiendaSucursal == null)
            {
                return NotFound();
            }

            return View(tiendaSucursal);
        }

        // GET: TiendaSucursals/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "IdTienda", "Codigo");
            return View();
        }

        // POST: TiendaSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTiendaSucursal,IdTienda,Direccion,Telefono,IdEmpleadoEncargado,Estado,FechaCreacion,FechaActualizacion")] TiendaSucursal tiendaSucursal)
        {
            if (ModelState.IsValid)
            {
                tiendaSucursal.FechaCreacion = DateTime.Now;
                _context.Add(tiendaSucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "IdTienda", "Codigo", tiendaSucursal.IdTienda);
            return View(tiendaSucursal);
        }

        // GET: TiendaSucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendaSucursal = await _context.TiendaSucursal.FindAsync(id);
            if (tiendaSucursal == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "IdTienda", "Codigo", tiendaSucursal.IdTienda);
            return View(tiendaSucursal);
        }

        // POST: TiendaSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTiendaSucursal,IdTienda,Direccion,Telefono,IdEmpleadoEncargado,Estado,FechaCreacion,FechaActualizacion")] TiendaSucursal tiendaSucursal)
        {
            if (id != tiendaSucursal.IdTiendaSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tiendaSucursal.FechaActualizacion = DateTime.Now;
                    _context.Update(tiendaSucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaSucursalExists(tiendaSucursal.IdTiendaSucursal))
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
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "IdTienda", "Codigo", tiendaSucursal.IdTienda);
            return View(tiendaSucursal);
        }

        // GET: TiendaSucursals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendaSucursal = await _context.TiendaSucursal
                .Include(t => t.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdTiendaSucursal == id);
            if (tiendaSucursal == null)
            {
                return NotFound();
            }

            return View(tiendaSucursal);
        }

        // POST: TiendaSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiendaSucursal = await _context.TiendaSucursal.FindAsync(id);
            _context.TiendaSucursal.Remove(tiendaSucursal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaSucursalExists(int id)
        {
            return _context.TiendaSucursal.Any(e => e.IdTiendaSucursal == id);
        }
    }
}
