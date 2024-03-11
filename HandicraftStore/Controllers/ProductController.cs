using HandicraftStore.Interface;
using HandicraftStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace HandicraftStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProduct _prod;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProduct product, IWebHostEnvironment webHost)
        {
            webHostEnvironment = webHost;
            _prod = product;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var prod = _prod.GetAll();
            return View(prod);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Product prod = new Product();
            return View(prod);
        }
        [HttpPost]
        public IActionResult Create(Product prod)
        {
            string uniqueFileName = UploadedFile(prod);
            prod.ImageUrl = uniqueFileName;
            _prod.Insert(prod);
            _prod.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var prod = _prod.GetById(Id);
            _prod.Delete(prod);
            _prod.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Product prod)
        {
            _prod.Delete(prod);
            _prod.Save();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var craft = _prod.GetById(Id);
            craft.imagepath = craft.ImageUrl;
            return View(craft);
        }
       
        public string GetUrl(int Id)
        {
            var craft = _prod.GetById(Id);
            return craft.ImageUrl; 
        }
        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            
            string uniqueFileName;
           
            if (prod.ImageUrl != null)
            {
                uniqueFileName = UploadedFile(prod);
                
            }
            else
            {
                uniqueFileName = prod.imagepath;// GetUrl(prod.Id);
            }
            
            prod.ImageUrl = uniqueFileName;
            _prod.Update(prod);
            _prod.Save();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private string UploadedFile(Product prod)
        {
            string uniqueFileName = null;
            if (prod.CraftImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + prod.CraftImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    prod.CraftImage.CopyTo(fileStream); 
                }
            }
            return uniqueFileName;

        }
    }
   
}
