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
            _context.ilis.Add(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
