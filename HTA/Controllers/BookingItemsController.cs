using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HTA.Models;

namespace HTA.Controllers
{
    public class BookingItemsController : Controller
    {
        private readonly HTAContext _context;

        public BookingItemsController(HTAContext context)
        {
            _context = context;    
        }

        // GET: BookingItems
        public async Task<IActionResult> Index()
        {
            var hTAContext = _context.BookingItems.Include(b => b.Service);
            return View(await hTAContext.ToListAsync());
        }

        // GET: BookingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingItem = await _context.BookingItems
                .Include(b => b.Service)
                .SingleOrDefaultAsync(m => m.BookingItemId == id);
            if (bookingItem == null)
            {
                return NotFound();
            }

            return View(bookingItem);
        }

        // GET: BookingItems/Create
        public IActionResult Create()
        {
            ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ServiceID", "ServiceID");
            return View();
        }

        // POST: BookingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingItemId,BookingId,ServiceId,ServiceDate,ServiceTimeID,PriestI,PriestII,PriestIII,PriestAlloted,NoUnits,Service_Fee")] BookingItem bookingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ServiceID", "ServiceID", bookingItem.ServiceID);
            return View(bookingItem);
        }

        // GET: BookingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingItem = await _context.BookingItems.SingleOrDefaultAsync(m => m.BookingItemId == id);
            if (bookingItem == null)
            {
                return NotFound();
            }
            ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ServiceID", "ServiceID", bookingItem.ServiceID);
            return View(bookingItem);
        }

        // POST: BookingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingItemId,BookingId,ServiceID,ServiceDate,ServiceTimeID,PriestI,PriestII,PriestIII,PriestAlloted,NoUnits,Service_Fee")] BookingItem bookingItem)
        {
            if (id != bookingItem.BookingItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingItemExists(bookingItem.BookingItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ServiceID", "ServiceID", bookingItem.ServiceID);
            return View(bookingItem);
        }

        // GET: BookingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingItem = await _context.BookingItems
                .Include(b => b.Service)
                .SingleOrDefaultAsync(m => m.BookingItemId == id);
            if (bookingItem == null)
            {
                return NotFound();
            }

            return View(bookingItem);
        }

        // POST: BookingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingItem = await _context.BookingItems.SingleOrDefaultAsync(m => m.BookingItemId == id);
            _context.BookingItems.Remove(bookingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookingItemExists(int id)
        {
            return _context.BookingItems.Any(e => e.BookingItemId == id);
        }
    }
}
