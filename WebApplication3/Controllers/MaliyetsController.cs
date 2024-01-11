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
              return _context.Maliyets != null ? 
                          View(await _context.Maliyets.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Maliyets'  is null.");
        }

        // GET: Maliyets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maliyets == null)
            {
                return NotFound();
            }

            var maliyet = await _context.Maliyets
                .FirstOrDefaultAsync(m => m.Maliyet_Id == id);
            if (maliyet == null)
            {
                return NotFound();
            }

            return View(maliyet);
        }

        // GET: Maliyets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maliyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maliyet_Id,isin_Adi,isin_Adedi,Tutari,pesin_Gelir,kar,idari_pay,shcek,iscilik,malzeme,ogretmen,ogrenci,Okul_Id")] Maliyet maliyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maliyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(maliyet);
        }

        // POST: Maliyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maliyet_Id,isin_Adi,isin_Adedi,Tutari,pesin_Gelir,kar,idari_pay,shcek,iscilik,malzeme,ogretmen,ogrenci,Okul_Id")] Maliyet maliyet)
        {
            if (id != maliyet.Maliyet_Id)
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
                    if (!MaliyetExists(maliyet.Maliyet_Id))
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
                .FirstOrDefaultAsync(m => m.Maliyet_Id == id);
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
          return (_context.Maliyets?.Any(e => e.Maliyet_Id == id)).GetValueOrDefault();
        }
    }
}
