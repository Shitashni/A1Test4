using HandicraftStore.Data;
using HandicraftStore.Interface;
using HandicraftStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandicraftStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public  UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        // GET: AccountController

        public AccountController(UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            var users =  _userManager.Users.ToList();

            return View(users);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }

            var usr =  _userManager.Users.Where(x=>x.Id==id).FirstOrDefault();
            if (usr == null)
            {
                return NotFound();
            }
            else
            {
                EditUser vm = new EditUser()
                {
                    Id = usr.Id,
                    FirstName = usr.FirstName,
                    LastName = usr.LastName,
                    PhoneNumber = usr.PhoneNumber
                };
                return View(vm);               
            }
            return View(usr);
        }
        public async Task<IActionResult> Edits(EditUser user)
        {
            ApplicationUser usr = await _userManager.FindByIdAsync(user.Id);
        if (usr == null)
            {
                ModelState.AddModelError("", "User not found");
            }
            else
            {
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.PhoneNumber = user.PhoneNumber;
                var result = await _userManager.UpdateAsync(usr);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
                else
                    return View();

            }
            return View(usr);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }

            var usr = _userManager.Users.Where(x => x.Id == id.ToString()).FirstOrDefault();
            if (usr == null)
            {
                return NotFound();
            }
            return View(usr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id,  ApplicationUser user)
        {
            if (id.ToString() != user.Id)
            {
                return NotFound();
            }
           var usr =await _userManager.FindByIdAsync(user.Id);
            if (usr == null)
            {
                ViewBag.ErrorMessage = $"User with Id= {id} cannot be found";
                return View("NotFound");
            }
            else { 
                
                 await  _userManager.DeleteAsync(usr);
                return RedirectToAction(nameof(Index));
            }
           // return View(user);
        }
        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
       

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
