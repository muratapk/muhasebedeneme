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
    public class PersonelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personels
        public async Task<IActionResult> Index()
        {
              return _context.Personels != null ? 
                          View(await _context.Personels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Personels'  is null.");
        }

        // GET: Personels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .FirstOrDefaultAsync(m => m.Personel_Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Personel_Id,AdSoyad,TcNo,Iban,Brans_Id")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personel);
        }

        // GET: Personels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Personel_Id,AdSoyad,TcNo,Iban,Brans_Id")] Personel personel)
        {
            if (id != personel.Personel_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.Personel_Id))
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
            return View(personel);
        }

        // GET: Personels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .FirstOrDefaultAsync(m => m.Personel_Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Personels'  is null.");
            }
            var personel = await _context.Personels.FindAsync(id);
            if (personel != null)
            {
                _context.Personels.Remove(personel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
          return (_context.Personels?.Any(e => e.Personel_Id == id)).GetValueOrDefault();
        }
    }
}
