using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin gelen)
        {
            var sorgu = _context.Admins.Where(x => x.AdminEmail == gelen.AdminEmail && x.AdminPassword == gelen.AdminPassword).FirstOrDefault();
            if(sorgu!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
            
            return View();
        }
    }
}
