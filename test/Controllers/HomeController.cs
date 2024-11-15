using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test.Models;
using test.Servies;
using test.ViewModel;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainServices mainServices;

        public HomeController(ILogger<HomeController> logger, MainServices mainServices)
        {
            _logger = logger;
            this.mainServices = mainServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region MAIN
        public IActionResult addmain()
        {

            return View();
        }
        public IActionResult addmain1(mainVm mv)
        {
            mainServices.addmain(mv);
            return RedirectToAction("GETALL");
        }
        public IActionResult GETALL()
        {
            var data = mainServices.GetMainitem();
            return View(data);
        } 
        public IActionResult Delete(int id)
        {
            var data = mainServices.GetMainitembyid(id);
            return View(data);
          
        } public IActionResult Delete1(int id)
        {
            var data = mainServices.delete(id);
            return RedirectToAction("GETALL");
        }public IActionResult Details(int id)
        {
            var data = mainServices.GetMainitembyid(id);
            return View(data);
        }public IActionResult Edit(mainVm id)
        {
            var data = mainServices.editemain(id);
            return View(data);
        }
        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
