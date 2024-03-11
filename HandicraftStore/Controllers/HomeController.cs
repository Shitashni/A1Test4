using HandicraftStore.Interface;
using HandicraftStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HandicraftStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // private readonly IHandicraft _handicraft;

        // private readonly ILogger<HomeController> _logger;

        //public HomeController(IHandicraft Handicraft)
        //{
        //    _handicraft = Handicraft;
        //}
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var handicrafts = _handicraft.GetAll();
        //    return View(handicrafts);
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Handicraft handicraft)
        //{
        //    _handicraft.Insert(handicraft);
        //    _handicraft.Save();
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Delete ( int Id)
        //{
        //    var craft = _handicraft.GetById(Id);
        //    return View(craft);
        //}
        //[HttpPost]
        //public IActionResult Delete(Handicraft handicraft)
        //{
        //    _handicraft.Delete(handicraft);
        //    _handicraft.Save();
        //    return View();
        //}

        //[HttpGet] 
        //public IActionResult Details(int Id)
        //{
        //    var craft = _handicraft.GetById(Id);
        //    return View(craft);
        //}
        //[HttpGet]
        //public IActionResult Edit(Handicraft handicraft)
        //{
        //   _handicraft.Update(handicraft);
        //    _handicraft.Save();
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}