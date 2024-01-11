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
    public class ilcesisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ilcesisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ilcesis
        public async Task<IActionResult> Index()
        {
              return _context.ilcesis != null ? 
                          View(await _context.ilcesis.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ilcesis'  is null.");
        }

        // GET: ilcesis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ilcesis == null)
            {
                return NotFound();
            }

            var ilcesi = await _context.ilcesis
                .FirstOrDefaultAsync(m => m.ilce_Id == id);
            if (ilcesi == null)
            {
                return NotFound();
            }

            return View(ilcesi);
        }

        // GET: ilcesis/Create
        public IActionResult Create()
        {
            ViewBag.kateliste = new SelectList(_context.ilis, "il_Id", "il_Adi");
            return View();
        }

        // POST: ilcesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ilce_Id,ilce_Adi,il_Id")] ilcesi ilcesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilcesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ilcesi);
        }

        // GET: ilcesis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.kateliste = new SelectList(_context.ilis, "il_Id", "il_Adi");
            if (id == null || _context.ilcesis == null)
            {
                return NotFound();
            }

            var ilcesi = await _context.ilcesis.FindAsync(id);
            if (ilcesi == null)
            {
                return NotFound();
            }
            return View(ilcesi);
        }

        // POST: ilcesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ilce_Id,ilce_Adi,il_Id")] ilcesi ilcesi)
        {
            if (id != ilcesi.ilce_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilcesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ilcesiExists(ilcesi.ilce_Id))
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
            return View(ilcesi);
        }

        // GET: ilcesis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ilcesis == null)
            {
                return NotFound();
            }

            var ilcesi = await _context.ilcesis
                .FirstOrDefaultAsync(m => m.ilce_Id == id);
            if (ilcesi == null)
            {
                return NotFound();
            }

            return View(ilcesi);
        }

        // POST: ilcesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ilcesis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ilcesis'  is null.");
            }
            var ilcesi = await _context.ilcesis.FindAsync(id);
            if (ilcesi != null)
            {
                _context.ilcesis.Remove(ilcesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ilcesiExists(int id)
        {
          return (_context.ilcesis?.Any(e => e.ilce_Id == id)).GetValueOrDefault();
        }
    }
}
