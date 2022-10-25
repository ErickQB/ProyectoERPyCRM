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
    public class SueldoVendedorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SueldoVendedorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SueldoVendedors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SueldoVendedor.Include(s => s.IdVendedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SueldoVendedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoVendedor = await _context.SueldoVendedor
                .Include(s => s.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdSueldoVendedor == id);
            if (sueldoVendedor == null)
            {
                return NotFound();
            }

            return View(sueldoVendedor);
        }

        // GET: SueldoVendedors/Create
        public IActionResult Create()
        {
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo");
            return View();
        }

        // POST: SueldoVendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSueldoVendedor,Mes,Anio,IdVendedor,TotalVenta,TotalComision,Descuento,TotalPago,Estado,FechaCreacion,FechaActualizacion")] SueldoVendedor sueldoVendedor)
        {
            if (ModelState.IsValid)
            {
                if (sueldoVendedor.Estado == "true")
                {
                    sueldoVendedor.Estado = "1";
                }
                else
                {
                    sueldoVendedor.Estado = "0";
                }
                sueldoVendedor.FechaCreacion = DateTime.Now;
                _context.Add(sueldoVendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", sueldoVendedor.IdVendedor);
            return View(sueldoVendedor);
        }

        // GET: SueldoVendedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoVendedor = await _context.SueldoVendedor.FindAsync(id);
            if (sueldoVendedor == null)
            {
                return NotFound();
            }
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", sueldoVendedor.IdVendedor);
            return View(sueldoVendedor);
        }

        // POST: SueldoVendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSueldoVendedor,Mes,Anio,IdVendedor,TotalVenta,TotalComision,Descuento,TotalPago,Estado,FechaCreacion,FechaActualizacion")] SueldoVendedor sueldoVendedor)
        {
            if (id != sueldoVendedor.IdSueldoVendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (sueldoVendedor.Estado == "0")
                    {
                        sueldoVendedor.Estado = "0";
                    }
                    else
                    {
                        sueldoVendedor.Estado = "1";
                    }
                    sueldoVendedor.FechaActualizacion = DateTime.Now;
                    _context.Update(sueldoVendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SueldoVendedorExists(sueldoVendedor.IdSueldoVendedor))
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
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", sueldoVendedor.IdVendedor);
            return View(sueldoVendedor);
        }

        // GET: SueldoVendedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoVendedor = await _context.SueldoVendedor
                .Include(s => s.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdSueldoVendedor == id);
            if (sueldoVendedor == null)
            {
                return NotFound();
            }

            return View(sueldoVendedor);
        }

        // POST: SueldoVendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sueldoVendedor = await _context.SueldoVendedor.FindAsync(id);
            _context.SueldoVendedor.Remove(sueldoVendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SueldoVendedorExists(int id)
        {
            return _context.SueldoVendedor.Any(e => e.IdSueldoVendedor == id);
        }
    }
}
