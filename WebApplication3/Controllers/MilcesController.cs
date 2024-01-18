using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MilcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Milces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Milces.Include(m => m.Mil);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Milces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Milces == null)
            {
                return NotFound();
            }

            var milce = await _context.Milces
                .Include(m => m.Mil)
                .FirstOrDefaultAsync(m => m.MilceId == id);
            if (milce == null)
            {
                return NotFound();
            }

            return View(milce);
        }

        // GET: Milces/Create
        public IActionResult Create()
        {
            ViewData["MilId"] = new SelectList(_context.Mils, "MilId", "MilAdi");
            return View();
        }

        // POST: Milces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilceId,MilceName,MilId")] Milce milce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MilId"] = new SelectList(_context.Mils, "MilId", "MilAdi", milce.MilId);
            return View(milce);
        }

        // GET: Milces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Milces == null)
            {
                return NotFound();
            }

            var milce = await _context.Milces.FindAsync(id);
            if (milce == null)
            {
                return NotFound();
            }
            ViewData["MilId"] = new SelectList(_context.Mils, "MilId", "MilAdi", milce.MilId);
            return View(milce);
        }

        // POST: Milces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilceId,MilceName,MilId")] Milce milce)
        {
            if (id != milce.MilceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilceExists(milce.MilceId))
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
            ViewData["MilId"] = new SelectList(_context.Mils, "MilId", "MilAdi", milce.MilId);
            return View(milce);
        }

        // GET: Milces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Milces == null)
            {
                return NotFound();
            }

            var milce = await _context.Milces
                .Include(m => m.Mil)
                .FirstOrDefaultAsync(m => m.MilceId == id);
            if (milce == null)
            {
                return NotFound();
            }

            return View(milce);
        }

        // POST: Milces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Milces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Milces'  is null.");
            }
            var milce = await _context.Milces.FindAsync(id);
            if (milce != null)
            {
                _context.Milces.Remove(milce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilceExists(int id)
        {
          return (_context.Milces?.Any(e => e.MilceId == id)).GetValueOrDefault();
        }
    }
}
