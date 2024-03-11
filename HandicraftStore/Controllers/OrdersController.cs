using HandicraftStore.Interface;
using HandicraftStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Authorization;

namespace HandicraftStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrders _txn;
        private readonly IProduct _prod;
        private readonly IWebHostEnvironment webHostEnvironment;
        //public TransactionController(ITransaction txn, IWebHostEnvironment webHost)
        //{
        //    webHostEnvironment = webHost;
        //    _txn = txn;
           
        //}
        public OrdersController(IOrders txn, IProduct product, IWebHostEnvironment webHost)
        {
            webHostEnvironment = webHost;
            _txn = txn;
            _prod = product;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var prod = _prod.GetAll();
            return View(prod);
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            List<Product> PROD = _prod.GetAll();
                return Json(PROD);
        }
       
        [HttpGet]
        public IActionResult GotoCart()//,string desc, string amount, string imageurl
        {
            ViewBag.TotalCost = 0;
            decimal cost = 0;
            var odr = _txn.GetAllByStatus("Input", User.Identity.Name);
            if (odr != null)
            {
                foreach(var item in odr)
                {
                    cost += item.Amount;
                }
            }
            ViewBag.TotalCost = cost;
            return View(odr);
        }
        [HttpGet]
        public IActionResult GetApprovedOrderByCust()//,string desc, string amount, string imageurl
        {
            var odr = _txn.GetAllByStatus("Approved", User.Identity.Name);
            return View(odr);
        }
        [HttpGet]
        public IActionResult GotoCartItem()//,string desc, string amount, string imageurl
        {

          //var odr = _txn.GetAllByStatus("Pending", User.Identity.Name);
          // // return RedirectToAction("ParsingRedirector", "Orders", new { List = "MasterDealer" });
          // return View(odr);
            return RedirectToAction("GotoCart", "Orders");

        }
        [HttpGet]
        public IActionResult DeleteCartById(int Id)
        {
            _txn.DeleteById(Id);
            return RedirectToAction("GotoCart", "Orders");
        }

        [HttpPost]
        public ActionResult SaveCartItems(int id)
        {
            var craft = _prod.GetById(id);
            string Imagepath = craft.ImageUrl;

            Orders orders = new Orders();
            orders.CreatedDate = DateTime.Now;
            orders.ProductId = id;
            orders.Quantity = 1;
            orders.Amount = Convert.ToDecimal( craft.Amount);
            orders.OrderStatus = "Input";
            orders.Email = User.Identity.Name;

            _txn.Insert(orders);
            _txn.Save();
            return RedirectToAction("Index", "Orders");

            
        }

           [HttpGet]
        public IActionResult ViewProduct(int Id)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            var craft = _prod.GetById(Id);
            //craft.ImageUrl = Path.Combine(uploadsFolder, craft.ImageUrl) ;
            return View(craft);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var txn = _txn.GetAll();
            return View(txn);
        }
        [HttpGet]
        public IActionResult ViewProcessedOrder()
        {
            var txn = _txn.GetAllByStatus("Approved");
            return View(txn);
        }
        [HttpGet]
        public IActionResult ViewProcessedOrderByCustomer()
        {
            var txn = _txn.GetOrderProcessedByCustomer(User.Identity.Name);
            return View(txn);
        }


        
        [HttpGet]
        public IActionResult Create()
        {
            Product prod = new Product();
            return View(prod);
        }
        [HttpPost]
        public IActionResult Create(Orders txn)
        {
            
            _txn.Insert(txn);
            _txn.Save();
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var prod = _txn.GetById(Id);
            _txn.Delete(prod);
            _txn.Save();
            return RedirectToAction("GotoCart", "Orders");
        }
        [HttpPost]
        public IActionResult Delete(Product prod)
        {
            _prod.Delete(prod);
            _prod.Save();
            return View();
        }

        [HttpGet]
        public IActionResult UpdateOrderStatus(int Id)
        {
            Orders txn = _txn.GetById(Id);
            txn.OrderStatus = "Approved";

            _txn.Update(txn);
            _txn.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeclineOrder(int Id)
        {
            Orders txn = _txn.GetById(Id);
           
                txn.OrderStatus = "Declined";
            _txn.Update(txn);
            _txn.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FinalizeOrder()
        {
            List<Orders> txn = _txn.GetOrderByCustomerId("Input",User.Identity.Name);
            foreach(var item in txn)
            {
                Orders ordrs = _txn.GetById(item.Id);

                ordrs.OrderStatus = "Pending";
               
                _txn.Update(ordrs);
                _txn.Save();
               
            }
           // GetApprovedOrderByCust();

            return RedirectToAction("ProductList", "Orders");
        }
    }
}
