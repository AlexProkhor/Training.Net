﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prokhor.Data;

namespace Prokhor.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

       
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.AsQueryable().Include<Order, Product>(x => x.Product).ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .AsQueryable().Include<Order, Product>(x => x.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        //public IActionResult Create()
        //{
        //    SelectList prods = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Name));
        //    SelectList shopBags = new SelectList(_context.ShopBags, nameof(ShopBag.ID), nameof(ShopBag.Name));
        //    ViewBag.ShopBags = shopBags;
        //    ViewBag.Products = prods;
        //    return View();
        //}

        //Во вью изменить выпадающий список на выбор модели.
        public IActionResult Create(Product product)
        {
            Product selectedProduct =/* _context.Products.Where(m => m.Id == i).First();*/ product;
            SelectList shopBags = new SelectList(_context.ShopBags, nameof(ShopBag.ID), nameof(ShopBag.Name));
            ViewBag.ShopBags = shopBags;
            ViewBag.Products = selectedProduct;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            SelectList prods = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Name));
            ViewBag.Products = prods;
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
