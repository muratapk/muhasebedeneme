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
    public class OkulsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OkulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Okuls
        public async Task<IActionResult> Index()
        {
              return _context.Okuls != null ? 
                          View(await _context.Okuls.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Okuls'  is null.");
        }

        // GET: Okuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Okuls == null)
            {
                return NotFound();
            }

            var okul = await _context.Okuls
                .FirstOrDefaultAsync(m => m.Okul_Id == id);
            if (okul == null)
            {
                return NotFound();
            }

            return View(okul);
        }

        // GET: Okuls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Okuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Okul_Id,OkulAdi,VergiNo,ilce_Id")] Okul okul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(okul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(okul);
        }

        // GET: Okuls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Okuls == null)
            {
                return NotFound();
            }

            var okul = await _context.Okuls.FindAsync(id);
            if (okul == null)
            {
                return NotFound();
            }
            return View(okul);
        }

        // POST: Okuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Okul_Id,OkulAdi,VergiNo,ilce_Id")] Okul okul)
        {
            if (id != okul.Okul_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(okul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OkulExists(okul.Okul_Id))
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
            return View(okul);
        }

        // GET: Okuls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Okuls == null)
            {
                return NotFound();
            }

            var okul = await _context.Okuls
                .FirstOrDefaultAsync(m => m.Okul_Id == id);
            if (okul == null)
            {
                return NotFound();
            }

            return View(okul);
        }

        // POST: Okuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Okuls == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Okuls'  is null.");
            }
            var okul = await _context.Okuls.FindAsync(id);
            if (okul != null)
            {
                _context.Okuls.Remove(okul);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OkulExists(int id)
        {
          return (_context.Okuls?.Any(e => e.Okul_Id == id)).GetValueOrDefault();
        }
    }
}
