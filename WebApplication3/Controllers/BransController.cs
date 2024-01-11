using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var listem = _context.Brans.ToList();
            return View(listem);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brans gelen)
        {
            _context.Brans.Add(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bul = _context.Brans.Find(id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(Brans gelen)
        {
            _context.Update(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _context.Brans.Find(id);
            return View(bul);
        }

        [HttpPost]
        public IActionResult Delete(Brans gelen)
        {
            _context.Remove(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
