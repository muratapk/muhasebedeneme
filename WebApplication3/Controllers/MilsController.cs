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
    public class MilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mils
        public async Task<IActionResult> Index()
        {
              return _context.Mils != null ? 
                          View(await _context.Mils.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mils'  is null.");
        }

        // GET: Mils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mils == null)
            {
                return NotFound();
            }

            var mil = await _context.Mils
                .FirstOrDefaultAsync(m => m.MilId == id);
            if (mil == null)
            {
                return NotFound();
            }

            return View(mil);
        }

        // GET: Mils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilId,MilAdi")] Mil mil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mil);
        }

        // GET: Mils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mils == null)
            {
                return NotFound();
            }

            var mil = await _context.Mils.FindAsync(id);
            if (mil == null)
            {
                return NotFound();
            }
            return View(mil);
        }

        // POST: Mils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilId,MilAdi")] Mil mil)
        {
            if (id != mil.MilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilExists(mil.MilId))
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
            return View(mil);
        }

        // GET: Mils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mils == null)
            {
                return NotFound();
            }

            var mil = await _context.Mils
                .FirstOrDefaultAsync(m => m.MilId == id);
            if (mil == null)
            {
                return NotFound();
            }

            return View(mil);
        }

        // POST: Mils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mils == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mils'  is null.");
            }
            var mil = await _context.Mils.FindAsync(id);
            if (mil != null)
            {
                _context.Mils.Remove(mil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilExists(int id)
        {
          return (_context.Mils?.Any(e => e.MilId == id)).GetValueOrDefault();
        }
    }
}
