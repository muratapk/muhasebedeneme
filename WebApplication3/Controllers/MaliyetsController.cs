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
    public class MaliyetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaliyetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maliyets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Maliyets.Include(m => m.Okul);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Maliyets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maliyets == null)
            {
                return NotFound();
            }

            var maliyet = await _context.Maliyets
                .Include(m => m.Okul)
                .FirstOrDefaultAsync(m => m.MaliyetId == id);
            if (maliyet == null)
            {
                return NotFound();
            }

            return View(maliyet);
        }

        // GET: Maliyets/Create
        public IActionResult Create()
        {
            ViewData["OkulId"] = new SelectList(_context.Okuls, "OkulId", "OkulId");
            return View();
        }

        // POST: Maliyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaliyetId,Isin_Adi,Isin_Adedi,Tutari,Pesin_Gelir,Kar,Idari_pay,Shcek,Iscilik,Malzeme,Ogretmen,Ogrenci,OkulId")] Maliyet maliyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maliyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OkulId"] = new SelectList(_context.Okuls, "OkulId", "OkulId", maliyet.OkulId);
            return View(maliyet);
        }

        // GET: Maliyets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maliyets == null)
            {
                return NotFound();
            }

            var maliyet = await _context.Maliyets.FindAsync(id);
            if (maliyet == null)
            {
                return NotFound();
            }
            ViewData["OkulId"] = new SelectList(_context.Okuls, "OkulId", "OkulId", maliyet.OkulId);
            return View(maliyet);
        }

        // POST: Maliyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaliyetId,Isin_Adi,Isin_Adedi,Tutari,Pesin_Gelir,Kar,Idari_pay,Shcek,Iscilik,Malzeme,Ogretmen,Ogrenci,OkulId")] Maliyet maliyet)
        {
            if (id != maliyet.MaliyetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maliyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaliyetExists(maliyet.MaliyetId))
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
            ViewData["OkulId"] = new SelectList(_context.Okuls, "OkulId", "OkulId", maliyet.OkulId);
            return View(maliyet);
        }

        // GET: Maliyets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maliyets == null)
            {
                return NotFound();
            }

            var maliyet = await _context.Maliyets
                .Include(m => m.Okul)
                .FirstOrDefaultAsync(m => m.MaliyetId == id);
            if (maliyet == null)
            {
                return NotFound();
            }

            return View(maliyet);
        }

        // POST: Maliyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maliyets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Maliyets'  is null.");
            }
            var maliyet = await _context.Maliyets.FindAsync(id);
            if (maliyet != null)
            {
                _context.Maliyets.Remove(maliyet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaliyetExists(int id)
        {
          return (_context.Maliyets?.Any(e => e.MaliyetId == id)).GetValueOrDefault();
        }
    }
}
