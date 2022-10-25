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
    public class EmpleadoSucursalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoSucursalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoSucursals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmpleadoSucursal.Include(e => e.IdDepartamentoNavigation).Include(e => e.IdEmpleadoNavigation).Include(e => e.IdTiendaSucursalNavigation).Include(e => e.IdVendedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmpleadoSucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoSucursal = await _context.EmpleadoSucursal
                .Include(e => e.IdDepartamentoNavigation)
                .Include(e => e.IdEmpleadoNavigation)
                .Include(e => e.IdTiendaSucursalNavigation)
                .Include(e => e.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoSucursal == id);
            if (empleadoSucursal == null)
            {
                return NotFound();
            }

            return View(empleadoSucursal);
        }

        // GET: EmpleadoSucursals/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "Codigo");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido");
            ViewData["IdTiendaSucursal"] = new SelectList(_context.TiendaSucursal, "IdTiendaSucursal", "Direccion");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo");
            return View();
        }

        // POST: EmpleadoSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleadoSucursal,IdTiendaSucursal,IdEmpleado,IdDepartamento,IdVendedor,Estado,FechaActualizacion,FechaCreacion")] EmpleadoSucursal empleadoSucursal)
        {
            if (ModelState.IsValid)
            {
                empleadoSucursal.FechaCreacion = DateTime.Now;
                _context.Add(empleadoSucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "Codigo", empleadoSucursal.IdDepartamento);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", empleadoSucursal.IdEmpleado);
            ViewData["IdTiendaSucursal"] = new SelectList(_context.TiendaSucursal, "IdTiendaSucursal", "Direccion", empleadoSucursal.IdTiendaSucursal);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", empleadoSucursal.IdVendedor);
            return View(empleadoSucursal);
        }

        // GET: EmpleadoSucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoSucursal = await _context.EmpleadoSucursal.FindAsync(id);
            if (empleadoSucursal == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "Codigo", empleadoSucursal.IdDepartamento);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", empleadoSucursal.IdEmpleado);
            ViewData["IdTiendaSucursal"] = new SelectList(_context.TiendaSucursal, "IdTiendaSucursal", "Direccion", empleadoSucursal.IdTiendaSucursal);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", empleadoSucursal.IdVendedor);
            return View(empleadoSucursal);
        }

        // POST: EmpleadoSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleadoSucursal,IdTiendaSucursal,IdEmpleado,IdDepartamento,IdVendedor,Estado,FechaActualizacion,FechaCreacion")] EmpleadoSucursal empleadoSucursal)
        {
            if (id != empleadoSucursal.IdEmpleadoSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    empleadoSucursal.FechaActualizacion = DateTime.Now;
                    _context.Update(empleadoSucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoSucursalExists(empleadoSucursal.IdEmpleadoSucursal))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "Codigo", empleadoSucursal.IdDepartamento);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Apellido", empleadoSucursal.IdEmpleado);
            ViewData["IdTiendaSucursal"] = new SelectList(_context.TiendaSucursal, "IdTiendaSucursal", "Direccion", empleadoSucursal.IdTiendaSucursal);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Codigo", empleadoSucursal.IdVendedor);
            return View(empleadoSucursal);
        }

        // GET: EmpleadoSucursals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoSucursal = await _context.EmpleadoSucursal
                .Include(e => e.IdDepartamentoNavigation)
                .Include(e => e.IdEmpleadoNavigation)
                .Include(e => e.IdTiendaSucursalNavigation)
                .Include(e => e.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoSucursal == id);
            if (empleadoSucursal == null)
            {
                return NotFound();
            }

            return View(empleadoSucursal);
        }

        // POST: EmpleadoSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleadoSucursal = await _context.EmpleadoSucursal.FindAsync(id);
            _context.EmpleadoSucursal.Remove(empleadoSucursal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoSucursalExists(int id)
        {
            return _context.EmpleadoSucursal.Any(e => e.IdEmpleadoSucursal == id);
        }
    }
}
