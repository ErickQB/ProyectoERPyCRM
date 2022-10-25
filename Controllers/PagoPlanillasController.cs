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
    public class PagoPlanillasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagoPlanillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PagoPlanillas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PagoPlanilla.Include(p => p.IdSueldoEmpleadoNavigation).Include(p => p.IdSueldoVendedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PagoPlanillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoPlanilla = await _context.PagoPlanilla
                .Include(p => p.IdSueldoEmpleadoNavigation)
                .Include(p => p.IdSueldoVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pagoPlanilla == null)
            {
                return NotFound();
            }

            return View(pagoPlanilla);
        }

        // GET: PagoPlanillas/Create
        public IActionResult Create()
        {
            ViewData["IdSueldoEmpleado"] = new SelectList(_context.SueldoEmpleado, "IdSueldoEmpleado", "IdSueldoEmpleado");
            ViewData["IdSueldoVendedor"] = new SelectList(_context.SueldoVendedor, "IdSueldoVendedor", "IdSueldoVendedor");
            return View();
        }

        // POST: PagoPlanillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,FechaPago,TipoPagoPlanilla,IdSueldoEmpleado,TotalSueldoEmpleado,IdSueldoVendedor,TotalSueldoVendedor,Estado,FechaCreacion,FechaActualizacion")] PagoPlanilla pagoPlanilla)
        {
            if (ModelState.IsValid)
            {
                pagoPlanilla.FechaCreacion = DateTime.Now;
                _context.Add(pagoPlanilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSueldoEmpleado"] = new SelectList(_context.SueldoEmpleado, "IdSueldoEmpleado", "IdSueldoEmpleado", pagoPlanilla.IdSueldoEmpleado);
            ViewData["IdSueldoVendedor"] = new SelectList(_context.SueldoVendedor, "IdSueldoVendedor", "IdSueldoVendedor", pagoPlanilla.IdSueldoVendedor);
            return View(pagoPlanilla);
        }

        // GET: PagoPlanillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoPlanilla = await _context.PagoPlanilla.FindAsync(id);
            if (pagoPlanilla == null)
            {
                return NotFound();
            }
            ViewData["IdSueldoEmpleado"] = new SelectList(_context.SueldoEmpleado, "IdSueldoEmpleado", "IdSueldoEmpleado", pagoPlanilla.IdSueldoEmpleado);
            ViewData["IdSueldoVendedor"] = new SelectList(_context.SueldoVendedor, "IdSueldoVendedor", "IdSueldoVendedor", pagoPlanilla.IdSueldoVendedor);
            return View(pagoPlanilla);
        }

        // POST: PagoPlanillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,FechaPago,TipoPagoPlanilla,IdSueldoEmpleado,TotalSueldoEmpleado,IdSueldoVendedor,TotalSueldoVendedor,Estado,FechaCreacion,FechaActualizacion")] PagoPlanilla pagoPlanilla)
        {
            if (id != pagoPlanilla.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pagoPlanilla.FechaActualizacion = DateTime.Now;
                    _context.Update(pagoPlanilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoPlanillaExists(pagoPlanilla.IdPago))
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
            ViewData["IdSueldoEmpleado"] = new SelectList(_context.SueldoEmpleado, "IdSueldoEmpleado", "IdSueldoEmpleado", pagoPlanilla.IdSueldoEmpleado);
            ViewData["IdSueldoVendedor"] = new SelectList(_context.SueldoVendedor, "IdSueldoVendedor", "IdSueldoVendedor", pagoPlanilla.IdSueldoVendedor);
            return View(pagoPlanilla);
        }

        // GET: PagoPlanillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoPlanilla = await _context.PagoPlanilla
                .Include(p => p.IdSueldoEmpleadoNavigation)
                .Include(p => p.IdSueldoVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pagoPlanilla == null)
            {
                return NotFound();
            }

            return View(pagoPlanilla);
        }

        // POST: PagoPlanillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagoPlanilla = await _context.PagoPlanilla.FindAsync(id);
            _context.PagoPlanilla.Remove(pagoPlanilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoPlanillaExists(int id)
        {
            return _context.PagoPlanilla.Any(e => e.IdPago == id);
        }
    }
}
