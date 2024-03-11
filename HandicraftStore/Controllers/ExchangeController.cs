using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HandicraftStore.Data;
using HandicraftStore.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace HandicraftStore.Controllers
{
    [Authorize]
    public class ExchangeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExchangeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Exchange
        public async Task<IActionResult> Index()
        {
              return _context.ExchangeRates != null ? 
                          View(await _context.ExchangeRates.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ExchangeRate'  is null.");
        }

        public IActionResult Calculator()
        {
            List<ExchangeRate> rates = new List<ExchangeRate>();
            rates = _context.ExchangeRates.ToList();

            //ViewBag.TransferAmt = 0;
              ViewBag.rate = new SelectList(rates, "Id", "Country");
            return View() ;
                       // Problem("Entity set 'ApplicationDbContext.ExchangeRate'  is null.");
        }
       
       

        // GET: Exchange/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }
        [HttpPost]
        public JsonResult GetRates(int? id)
        {
            var exchangeRate = _context.ExchangeRates
               .FirstOrDefault(m => m.Id == id);
            if (exchangeRate == null)
            {
                //return NotFound();
            }
            return Json(exchangeRate.Rate);
        }
        //public ActionResult GetRate(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}

        //    var exchangeRate =  _context.ExchangeRates
        //        .FirstOrDefault(m => m.Id == id);
        //    if (exchangeRate == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("ViewPartOd", po);
        //}

        // GET: Exchange/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Agent()
        {
            return View();
        }

        // POST: Exchange/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,Rate")] ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exchangeRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        // GET: Exchange/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        // POST: Exchange/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,Rate")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        // GET: Exchange/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: Exchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExchangeRates == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExchangeRate'  is null.");
            }
            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate != null)
            {
                _context.ExchangeRates.Remove(exchangeRate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(int id)
        {
          return (_context.ExchangeRates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
