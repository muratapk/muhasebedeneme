using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

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
    }
}
