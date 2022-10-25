using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoX.Data;
using ProyectoX.Models;

using System.Data;
using System.IO;
using Grpc.Core;
using Reporteria_CRM;
using Reporteria_CRM.Vehiculos;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoX.Controllers
{
    [Authorize]
    public class VehiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,Tipo,Uso,Marca,Modelo,Linea,Placa,Chasis,Serie,Color,Asientos,Cilindraje,Estado,FechaCreacion,FechaActualizacion")] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                vehiculos.FechaCreacion = DateTime.Now;
                _context.Add(vehiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }
            return View(vehiculos);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,Tipo,Uso,Marca,Modelo,Linea,Placa,Chasis,Serie,Color,Asientos,Cilindraje,Estado,FechaCreacion,FechaActualizacion")] Vehiculos vehiculos)
        {
            if (id != vehiculos.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vehiculos.FechaActualizacion = DateTime.Now;
                    _context.Update(vehiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosExists(vehiculos.IdVehiculo))
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
            return View(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculos = await _context.Vehiculos.FindAsync(id);
            _context.Vehiculos.Remove(vehiculos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.IdVehiculo == id);
        }

        public ActionResult Download_PDF()
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            return File(ruta, "application/pdf", "Suivie Historique.pdf");
        }

    }
}
