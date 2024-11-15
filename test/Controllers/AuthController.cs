using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
    public class AuthController : Controller
    {
        private readonly applictioncontext _context;

        public AuthController(applictioncontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            
            if (_context.Users.Any(u => u.email == email))
            {
                ViewBag.Error = "Email is already registered.";
                return View();
            }

            
            var user = new Users { Name = name, email = email, password = password };
            _context.Users.Add(user);
            _context.SaveChanges();

            
            HttpContext.Session.SetInt32("UserId", user.id);
            HttpContext.Session.SetString("UserName", user.Name);
            return RedirectToAction("Index", "Purchase");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.email == email && u.password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);

                HttpContext.Session.SetInt32("UserId", user.id);
                return RedirectToAction("Index", "Purchase");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
