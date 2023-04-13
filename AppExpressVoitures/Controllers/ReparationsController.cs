using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppExpressVoitures.Data;
using AppExpressVoitures.Models;

namespace AppExpressVoitures.Controllers
{
    public class ReparationsController : Controller
    {
        private readonly MonContextDeBaseDeDonnees _context;

        public ReparationsController(MonContextDeBaseDeDonnees context)
        {
            _context = context;
        }

        // GET: Reparations
        public async Task<IActionResult> Index()
        {
              return _context.Reparations != null ? 
                          View(await _context.Reparations.ToListAsync()) :
                          Problem("Entity set 'MonContextDeBaseDeDonnees.Reparations'  is null.");
        }

        // GET: Reparations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations
                .FirstOrDefaultAsync(m => m.ReparationId == id);
            if (reparations == null)
            {
                return NotFound();
            }

            return View(reparations);
        }

        // GET: Reparations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reparations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReparationId,DatePriseEnCharge,DateDelivrance,VinId")] Reparations reparations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reparations);
        }

        // GET: Reparations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations.FindAsync(id);
            if (reparations == null)
            {
                return NotFound();
            }
            return View(reparations);
        }

        // POST: Reparations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReparationId,DatePriseEnCharge,DateDelivrance,VinId")] Reparations reparations)
        {
            if (id != reparations.ReparationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationsExists(reparations.ReparationId))
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
            return View(reparations);
        }

        // GET: Reparations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations
                .FirstOrDefaultAsync(m => m.ReparationId == id);
            if (reparations == null)
            {
                return NotFound();
            }

            return View(reparations);
        }

        // POST: Reparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reparations == null)
            {
                return Problem("Entity set 'MonContextDeBaseDeDonnees.Reparations'  is null.");
            }
            var reparations = await _context.Reparations.FindAsync(id);
            if (reparations != null)
            {
                _context.Reparations.Remove(reparations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparationsExists(int id)
        {
          return (_context.Reparations?.Any(e => e.ReparationId == id)).GetValueOrDefault();
        }
    }
}
