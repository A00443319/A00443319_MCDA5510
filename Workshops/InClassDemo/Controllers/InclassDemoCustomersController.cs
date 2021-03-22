using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClassDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InClassDemo.Controllers
{
    public class InclassDemoCustomersController : Controller
    {
        private readonly _5510Context _context;

        public InclassDemoCustomersController(_5510Context context)
        {
            _context = context;
        }

        // GET: InclassDemoCustomers
        public async Task<IActionResult> Index()
        {
            return View(await _context.InclassDemoCustomer.ToListAsync());
        }

        // GET: InclassDemoCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclassDemoCustomer = await _context.InclassDemoCustomer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inclassDemoCustomer == null)
            {
                return NotFound();
            }

            return View(inclassDemoCustomer);
        }

        // GET: InclassDemoCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InclassDemoCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FName,LName,Email")] InclassDemoCustomer inclassDemoCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inclassDemoCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inclassDemoCustomer);
        }

        // GET: InclassDemoCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclassDemoCustomer = await _context.InclassDemoCustomer.FindAsync(id);
            if (inclassDemoCustomer == null)
            {
                return NotFound();
            }
            return View(inclassDemoCustomer);
        }

        // POST: InclassDemoCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FName,LName,Email")] InclassDemoCustomer inclassDemoCustomer)
        {
            if (id != inclassDemoCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inclassDemoCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InclassDemoCustomerExists(inclassDemoCustomer.Id))
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
            return View(inclassDemoCustomer);
        }

        // GET: InclassDemoCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclassDemoCustomer = await _context.InclassDemoCustomer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inclassDemoCustomer == null)
            {
                return NotFound();
            }

            return View(inclassDemoCustomer);
        }

        // POST: InclassDemoCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inclassDemoCustomer = await _context.InclassDemoCustomer.FindAsync(id);
            _context.InclassDemoCustomer.Remove(inclassDemoCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InclassDemoCustomerExists(int id)
        {
            return _context.InclassDemoCustomer.Any(e => e.Id == id);
        }
    }
}
