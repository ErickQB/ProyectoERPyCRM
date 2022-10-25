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
    public class EnvioVentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvioVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnvioVentas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EnvioVenta.Include(e => e.IdDespachoNavigation).Include(e => e.IdTransporteEntregaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EnvioVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envioVenta = await _context.EnvioVenta
                .Include(e => e.IdDespachoNavigation)
                .Include(e => e.IdTransporteEntregaNavigation)
                .FirstOrDefaultAsync(m => m.IdEnvioVenta == id);
            if (envioVenta == null)
            {
                return NotFound();
            }

            return View(envioVenta);
        }

        // GET: EnvioVentas/Create
        public IActionResult Create()
        {
            ViewData["IdDespacho"] = new SelectList(_context.Despacho, "IdDespacho", "LugarDespacho");
            ViewData["IdTransporteEntrega"] = new SelectList(_context.TransporteEntrega, "IdTransporteEntrega", "IdTransporteEntrega");
            return View();
        }

        // POST: EnvioVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnvioVenta,IdDespacho,IdTransporteEntrega,DiaSalida,HoraSalida,DiaEntrega,HoraEntrega,DireccionEntrega,TipoEnvio,ContactoRecibir,Estado,FechaCreacion,FechaActualizacion")] EnvioVenta envioVenta)
        {
            if (ModelState.IsValid)
            {
                envioVenta.FechaCreacion = DateTime.Now;
                _context.Add(envioVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDespacho"] = new SelectList(_context.Despacho, "IdDespacho", "LugarDespacho", envioVenta.IdDespacho);
            ViewData["IdTransporteEntrega"] = new SelectList(_context.TransporteEntrega, "IdTransporteEntrega", "IdTransporteEntrega", envioVenta.IdTransporteEntrega);
            return View(envioVenta);
        }

        // GET: EnvioVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envioVenta = await _context.EnvioVenta.FindAsync(id);
            if (envioVenta == null)
            {
                return NotFound();
            }
            ViewData["IdDespacho"] = new SelectList(_context.Despacho, "IdDespacho", "LugarDespacho", envioVenta.IdDespacho);
            ViewData["IdTransporteEntrega"] = new SelectList(_context.TransporteEntrega, "IdTransporteEntrega", "IdTransporteEntrega", envioVenta.IdTransporteEntrega);
            return View(envioVenta);
        }

        // POST: EnvioVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnvioVenta,IdDespacho,IdTransporteEntrega,DiaSalida,HoraSalida,DiaEntrega,HoraEntrega,DireccionEntrega,TipoEnvio,ContactoRecibir,Estado,FechaCreacion,FechaActualizacion")] EnvioVenta envioVenta)
        {
            if (id != envioVenta.IdEnvioVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    envioVenta.FechaActualizacion = DateTime.Now;
                    _context.Update(envioVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioVentaExists(envioVenta.IdEnvioVenta))
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
            ViewData["IdDespacho"] = new SelectList(_context.Despacho, "IdDespacho", "LugarDespacho", envioVenta.IdDespacho);
            ViewData["IdTransporteEntrega"] = new SelectList(_context.TransporteEntrega, "IdTransporteEntrega", "IdTransporteEntrega", envioVenta.IdTransporteEntrega);
            return View(envioVenta);
        }

        // GET: EnvioVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envioVenta = await _context.EnvioVenta
                .Include(e => e.IdDespachoNavigation)
                .Include(e => e.IdTransporteEntregaNavigation)
                .FirstOrDefaultAsync(m => m.IdEnvioVenta == id);
            if (envioVenta == null)
            {
                return NotFound();
            }

            return View(envioVenta);
        }

        // POST: EnvioVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var envioVenta = await _context.EnvioVenta.FindAsync(id);
            _context.EnvioVenta.Remove(envioVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioVentaExists(int id)
        {
            return _context.EnvioVenta.Any(e => e.IdEnvioVenta == id);
        }
    }
}
