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
    public class TipoConsumoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoConsumoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoConsumoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoConsumo.ToListAsync());
        }

        // GET: TipoConsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumo = await _context.TipoConsumo
                .FirstOrDefaultAsync(m => m.IdTipoConsumo == id);
            if (tipoConsumo == null)
            {
                return NotFound();
            }

            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoConsumo,Nombre,Descripcion,Estado,FechaCreacion,FechaActualizacion")] TipoConsumo tipoConsumo)
        {
            if (ModelState.IsValid)
            {
                tipoConsumo.FechaCreacion = DateTime.Now;
                _context.Add(tipoConsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumo = await _context.TipoConsumo.FindAsync(id);
            if (tipoConsumo == null)
            {
                return NotFound();
            }
            return View(tipoConsumo);
        }

        // POST: TipoConsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoConsumo,Nombre,Descripcion,Estado,FechaCreacion,FechaActualizacion")] TipoConsumo tipoConsumo)
        {
            if (id != tipoConsumo.IdTipoConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tipoConsumo.FechaActualizacion = DateTime.Now;
                    _context.Update(tipoConsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoConsumoExists(tipoConsumo.IdTipoConsumo))
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
            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumo = await _context.TipoConsumo
                .FirstOrDefaultAsync(m => m.IdTipoConsumo == id);
            if (tipoConsumo == null)
            {
                return NotFound();
            }

            return View(tipoConsumo);
        }

        // POST: TipoConsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoConsumo = await _context.TipoConsumo.FindAsync(id);
            _context.TipoConsumo.Remove(tipoConsumo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoConsumoExists(int id)
        {
            return _context.TipoConsumo.Any(e => e.IdTipoConsumo == id);
        }
    }
}
