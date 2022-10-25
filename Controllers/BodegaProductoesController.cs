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
    public class BodegaProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodegaProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BodegaProductoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BodegaProducto.Include(b => b.IdBodegaNavigation).Include(b => b.IdProductoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BodegaProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaProducto = await _context.BodegaProducto
                .Include(b => b.IdBodegaNavigation)
                .Include(b => b.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdBodegaProducto == id);
            if (bodegaProducto == null)
            {
                return NotFound();
            }

            return View(bodegaProducto);
        }

        // GET: BodegaProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdBodega"] = new SelectList(_context.Bodega, "IdBodega", "Codigo");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: BodegaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBodegaProducto,IdBodega,IdProducto,NoEdificio,Nivel,Habitacion,Estanteria,NivelEstanteria,PosicionEstanteria,Cantidad,Estado,FechaCreacion,FechaActualizacion")] BodegaProducto bodegaProducto)
        {
            if (ModelState.IsValid)
            {
                bodegaProducto.FechaCreacion = DateTime.Now;
                _context.Add(bodegaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBodega"] = new SelectList(_context.Bodega, "IdBodega", "Codigo", bodegaProducto.IdBodega);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", bodegaProducto.IdProducto);
            return View(bodegaProducto);
        }

        // GET: BodegaProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaProducto = await _context.BodegaProducto.FindAsync(id);
            if (bodegaProducto == null)
            {
                return NotFound();
            }
            ViewData["IdBodega"] = new SelectList(_context.Bodega, "IdBodega", "Codigo", bodegaProducto.IdBodega);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", bodegaProducto.IdProducto);
            return View(bodegaProducto);
        }

        // POST: BodegaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBodegaProducto,IdBodega,IdProducto,NoEdificio,Nivel,Habitacion,Estanteria,NivelEstanteria,PosicionEstanteria,Cantidad,Estado,FechaCreacion,FechaActualizacion")] BodegaProducto bodegaProducto)
        {
            if (id != bodegaProducto.IdBodegaProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bodegaProducto.FechaActualizacion = DateTime.Now;
                    _context.Update(bodegaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaProductoExists(bodegaProducto.IdBodegaProducto))
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
            ViewData["IdBodega"] = new SelectList(_context.Bodega, "IdBodega", "Codigo", bodegaProducto.IdBodega);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", bodegaProducto.IdProducto);
            return View(bodegaProducto);
        }

        // GET: BodegaProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaProducto = await _context.BodegaProducto
                .Include(b => b.IdBodegaNavigation)
                .Include(b => b.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdBodegaProducto == id);
            if (bodegaProducto == null)
            {
                return NotFound();
            }

            return View(bodegaProducto);
        }

        // POST: BodegaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodegaProducto = await _context.BodegaProducto.FindAsync(id);
            _context.BodegaProducto.Remove(bodegaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaProductoExists(int id)
        {
            return _context.BodegaProducto.Any(e => e.IdBodegaProducto == id);
        }
    }
}
