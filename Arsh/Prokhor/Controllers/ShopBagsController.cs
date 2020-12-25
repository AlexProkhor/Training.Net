using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prokhor.Data;

namespace Prokhor.Controllers
{
    public class ShopBagsController : Controller
    {
        private readonly AppDbContext _context;

        public ShopBagsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ShopBags
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopBags.ToListAsync());
        }

        // GET: ShopBags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopBag = await _context.ShopBags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shopBag == null)
            {
                return NotFound();
            }
            shopBag.Orders = await _context.Set<Order>().AsNoTracking()
                .Where(x => x.ShopBagId == shopBag.ID)
                .AsQueryable().Include<Order, Product>(x => x.Product)
                .ToListAsync();
            return View(shopBag);
        }

        // GET: ShopBags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopBags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Name")] ShopBag shopBag)
        {
            shopBag.Status = "Preparation";
            shopBag.IsItPaid = false;
            if (ModelState.IsValid)
            {
                _context.Add(shopBag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopBag);
        }

        // GET: ShopBags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopBag = await _context.ShopBags.FindAsync(id);
            if (shopBag == null)
            {
                return NotFound();
            }
            shopBag.Orders = await _context.Set<Order>().AsNoTracking()
               .Where(x => x.ShopBagId == shopBag.ID)
               .AsQueryable().Include<Order, Product>(x => x.Product)
               .ToListAsync();
            return View(shopBag);
        }

        // POST: ShopBags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Name, IsItPaid, Status")] ShopBag shopBag)
        {
            if (id != shopBag.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopBag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopBagExists(shopBag.ID))
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
            return View(shopBag);
        }

        // GET: ShopBags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopBag = await _context.ShopBags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shopBag == null)
            {
                return NotFound();
            }

            return View(shopBag);
        }

        // POST: ShopBags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopBag = await _context.ShopBags.FindAsync(id);
            _context.ShopBags.Remove(shopBag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //public Task<IActionResult> Pay()
        //{
        //    return "Paid!";
        //}

        public async Task<IActionResult> Pay([Bind("ID, Name, IsItPaid, Status")] ShopBag shopBag)
        {
            shopBag.IsItPaid = true;
            _context.Update(shopBag);
            await _context.SaveChangesAsync();
            return View(shopBag);
        }

        private bool ShopBagExists(int id)
        {
            return _context.ShopBags.Any(e => e.ID == id);
        }
    }
}
