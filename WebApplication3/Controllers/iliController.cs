using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    
    public class iliController : Controller
    {

        private readonly ApplicationDbContext _context;

        public iliController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listem=_context.ilis.ToList();
            return View(listem);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ili gelen)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _context.ilis.Add(gelen);
            _context.SaveChanges();
            TempData["Success"] = "Kayıt Eklendi";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bul = _context.ilis.Find(id);
            return View(bul);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _context.ilis.Find(id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(ili gelen)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _context.ilis.Update(gelen);
            _context.SaveChanges();
            TempData["Success"] = "Kayıt Güncellendi";
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public IActionResult Delete(ili gelen)
        {
            _context.ilis.Remove(gelen);
            _context.SaveChanges();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
