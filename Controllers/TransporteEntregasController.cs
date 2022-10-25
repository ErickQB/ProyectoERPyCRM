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
    public class TransporteEntregasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransporteEntregasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransporteEntregas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransporteEntrega.Include(t => t.IdConductorNavigation).Include(t => t.IdVehiculoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransporteEntregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteEntrega = await _context.TransporteEntrega
                .Include(t => t.IdConductorNavigation)
                .Include(t => t.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdTransporteEntrega == id);
            if (transporteEntrega == null)
            {
                return NotFound();
            }

            return View(transporteEntrega);
        }

        // GET: TransporteEntregas/Create
        public IActionResult Create()
        {
            ViewData["IdConductor"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Marca");
            return View();
        }

        // POST: TransporteEntregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransporteEntrega,IdVehiculo,IdConductor,HoraSalida,FechaSalida,HoraRegreso,FechaRegreso,KilometrajeSalida,KilometrajeEntrada,Estado,FechaCreacion,FechaActualizacion")] TransporteEntrega transporteEntrega)
        {
            if (ModelState.IsValid)
            {
                transporteEntrega.FechaCreacion = DateTime.Now;
                _context.Add(transporteEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConductor"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", transporteEntrega.IdConductor);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Marca", transporteEntrega.IdVehiculo);
            return View(transporteEntrega);
        }

        // GET: TransporteEntregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteEntrega = await _context.TransporteEntrega.FindAsync(id);
            if (transporteEntrega == null)
            {
                return NotFound();
            }
            ViewData["IdConductor"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", transporteEntrega.IdConductor);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Marca", transporteEntrega.IdVehiculo);
            return View(transporteEntrega);
        }

        // POST: TransporteEntregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransporteEntrega,IdVehiculo,IdConductor,HoraSalida,FechaSalida,HoraRegreso,FechaRegreso,KilometrajeSalida,KilometrajeEntrada,Estado,FechaCreacion,FechaActualizacion")] TransporteEntrega transporteEntrega)
        {
            if (id != transporteEntrega.IdTransporteEntrega)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    transporteEntrega.FechaActualizacion = DateTime.Now;
                    _context.Update(transporteEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteEntregaExists(transporteEntrega.IdTransporteEntrega))
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
            ViewData["IdConductor"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", transporteEntrega.IdConductor);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Marca", transporteEntrega.IdVehiculo);
            return View(transporteEntrega);
        }

        // GET: TransporteEntregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteEntrega = await _context.TransporteEntrega
                .Include(t => t.IdConductorNavigation)
                .Include(t => t.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdTransporteEntrega == id);
            if (transporteEntrega == null)
            {
                return NotFound();
            }

            return View(transporteEntrega);
        }

        // POST: TransporteEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporteEntrega = await _context.TransporteEntrega.FindAsync(id);
            _context.TransporteEntrega.Remove(transporteEntrega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteEntregaExists(int id)
        {
            return _context.TransporteEntrega.Any(e => e.IdTransporteEntrega == id);
        }
    }
}
