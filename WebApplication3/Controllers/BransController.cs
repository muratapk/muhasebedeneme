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
    public class BransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Brans
        public async Task<IActionResult> Index()
        {
              return _context.Brans != null ? 
                          View(await _context.Brans.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Brans'  is null.");
        }

        // GET: Brans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brans == null)
            {
                return NotFound();
            }

            var brans = await _context.Brans
                .FirstOrDefaultAsync(m => m.Brans_Id == id);
            if (brans == null)
            {
                return NotFound();
            }

            return View(brans);
        }

        // GET: Brans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brans_Id,Brans_Adi")] Brans brans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brans);
        }

        // GET: Brans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brans == null)
            {
                return NotFound();
            }

            var brans = await _context.Brans.FindAsync(id);
            if (brans == null)
            {
                return NotFound();
            }
            return View(brans);
        }

        // POST: Brans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brans_Id,Brans_Adi")] Brans brans)
        {
            if (id != brans.Brans_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BransExists(brans.Brans_Id))
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
            return View(brans);
        }

        // GET: Brans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brans == null)
            {
                return NotFound();
            }

            var brans = await _context.Brans
                .FirstOrDefaultAsync(m => m.Brans_Id == id);
            if (brans == null)
            {
                return NotFound();
            }

            return View(brans);
        }

        // POST: Brans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brans == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Brans'  is null.");
            }
            var brans = await _context.Brans.FindAsync(id);
            if (brans != null)
            {
                _context.Brans.Remove(brans);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BransExists(int id)
        {
          return (_context.Brans?.Any(e => e.Brans_Id == id)).GetValueOrDefault();
        }
    }
}
