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
    public class SueldoEmpleadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SueldoEmpleadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SueldoEmpleadoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SueldoEmpleado.Include(s => s.IdEmpleadoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SueldoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoEmpleado = await _context.SueldoEmpleado
                .Include(s => s.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdSueldoEmpleado == id);
            if (sueldoEmpleado == null)
            {
                return NotFound();
            }

            return View(sueldoEmpleado);
        }

        // GET: SueldoEmpleadoes/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido");
            return View();
        }

        // POST: SueldoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSueldoEmpleado,Mes,Anio,IdEmpleado,Descuento,TotalPago,Estado,FechaCreacion,FechaActualizacion")] SueldoEmpleado sueldoEmpleado)
        {
            if (ModelState.IsValid)
            {
                if (sueldoEmpleado.Estado == "true")
                {
                    sueldoEmpleado.Estado = "1";
                }
                else
                {
                    sueldoEmpleado.Estado = "0";
                }
                sueldoEmpleado.FechaCreacion = DateTime.Now;
                _context.Add(sueldoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", sueldoEmpleado.IdEmpleado);
            return View(sueldoEmpleado);
        }

        // GET: SueldoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoEmpleado = await _context.SueldoEmpleado.FindAsync(id);
            if (sueldoEmpleado == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", sueldoEmpleado.IdEmpleado);
            return View(sueldoEmpleado);
        }

        // POST: SueldoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSueldoEmpleado,Mes,Anio,IdEmpleado,Descuento,TotalPago,Estado,FechaCreacion,FechaActualizacion")] SueldoEmpleado sueldoEmpleado)
        {
            if (id != sueldoEmpleado.IdSueldoEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (sueldoEmpleado.Estado == "0")
                    {
                        sueldoEmpleado.Estado = "0";
                    }
                    else
                    {
                        sueldoEmpleado.Estado = "1";
                    }
                    sueldoEmpleado.FechaActualizacion = DateTime.Now;
                    _context.Update(sueldoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SueldoEmpleadoExists(sueldoEmpleado.IdSueldoEmpleado))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", sueldoEmpleado.IdEmpleado);
            return View(sueldoEmpleado);
        }

        // GET: SueldoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sueldoEmpleado = await _context.SueldoEmpleado
                .Include(s => s.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdSueldoEmpleado == id);
            if (sueldoEmpleado == null)
            {
                return NotFound();
            }

            return View(sueldoEmpleado);
        }

        // POST: SueldoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sueldoEmpleado = await _context.SueldoEmpleado.FindAsync(id);
            _context.SueldoEmpleado.Remove(sueldoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SueldoEmpleadoExists(int id)
        {
            return _context.SueldoEmpleado.Any(e => e.IdSueldoEmpleado == id);
        }
    }
}
