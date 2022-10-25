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
    public class CobroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CobroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cobroes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cobro.Include(c => c.IdFacturaNavigation).Include(c => c.IdTipoPagoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cobroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro
                .Include(c => c.IdFacturaNavigation)
                .Include(c => c.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdCobro == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // GET: Cobroes/Create
        public IActionResult Create()
        {
            ViewData["IdFactura"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo");
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre");
            return View();
        }

        // POST: Cobroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCobro,IdFactura,Fecha,IdTipoPago,Correlativo,Estado,FechaCreacion,FechaActualizacion")] Cobro cobro)
        {
            if (ModelState.IsValid)
            {
                cobro.FechaCreacion = DateTime.Now;
                _context.Add(cobro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFactura"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", cobro.IdFactura);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", cobro.IdTipoPago);
            return View(cobro);
        }

        // GET: Cobroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro.FindAsync(id);
            if (cobro == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", cobro.IdFactura);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", cobro.IdTipoPago);
            return View(cobro);
        }

        // POST: Cobroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCobro,IdFactura,Fecha,IdTipoPago,Correlativo,Estado,FechaCreacion,FechaActualizacion")] Cobro cobro)
        {
            if (id != cobro.IdCobro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cobro.FechaActualizacion = DateTime.Now;
                    _context.Update(cobro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobroExists(cobro.IdCobro))
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
            ViewData["IdFactura"] = new SelectList(_context.FacturaVenta, "IdFacturaVenta", "Correlativo", cobro.IdFactura);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPago, "IdTipoPago", "Nombre", cobro.IdTipoPago);
            return View(cobro);
        }

        // GET: Cobroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro
                .Include(c => c.IdFacturaNavigation)
                .Include(c => c.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdCobro == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // POST: Cobroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobro = await _context.Cobro.FindAsync(id);
            _context.Cobro.Remove(cobro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobroExists(int id)
        {
            return _context.Cobro.Any(e => e.IdCobro == id);
        }
    }
}
