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
    public class HesapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HesapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hesaps
        public async Task<IActionResult> Index()
        {
              return _context.Hesaps != null ? 
                          View(await _context.Hesaps.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Hesaps'  is null.");
        }

        // GET: Hesaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hesaps == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesaps
                .FirstOrDefaultAsync(m => m.Hesap_Id == id);
            if (hesap == null)
            {
                return NotFound();
            }

            return View(hesap);
        }

        // GET: Hesaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hesaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hesap_Id,Maliyet_Id,Personel_Id,Adet")] Hesap hesap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hesap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hesap);
        }

        // GET: Hesaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hesaps == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesaps.FindAsync(id);
            if (hesap == null)
            {
                return NotFound();
            }
            return View(hesap);
        }

        // POST: Hesaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hesap_Id,Maliyet_Id,Personel_Id,Adet")] Hesap hesap)
        {
            if (id != hesap.Hesap_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hesap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HesapExists(hesap.Hesap_Id))
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
            return View(hesap);
        }

        // GET: Hesaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hesaps == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesaps
                .FirstOrDefaultAsync(m => m.Hesap_Id == id);
            if (hesap == null)
            {
                return NotFound();
            }

            return View(hesap);
        }

        // POST: Hesaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hesaps == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hesaps'  is null.");
            }
            var hesap = await _context.Hesaps.FindAsync(id);
            if (hesap != null)
            {
                _context.Hesaps.Remove(hesap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HesapExists(int id)
        {
          return (_context.Hesaps?.Any(e => e.Hesap_Id == id)).GetValueOrDefault();
        }
    }
}
