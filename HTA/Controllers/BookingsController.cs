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
    public class BookingsController : Controller
    {
        private readonly HTAContext _context;

        public BookingsController(HTAContext context)
        {
            _context = context;    
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var hTAContext = _context.Bookings.Include(b => b.Devotee);
            return View(await hTAContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Devotee)
                .SingleOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID");
            var DevoteeList = _context.Devotees.Where(d => d.Is_Active == true).OrderBy(d => d.First_Name).Select(d => new
            {
                Devotee_ID = d.Devotee_ID,
                First_Name = string.Format("{0} {1}", d.First_Name, d.Last_Name)
            }).ToList();
            DevoteeList.Insert(0, new { Devotee_ID= 0, First_Name="--Select Devotee--" });
            ViewBag.DevoteeNames = new SelectList(DevoteeList, "Devotee_ID", "First_Name");
            ViewBag.ServiceGroupId = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_Name");
            ViewBag.ServiceId = new SelectList(_context.Services, "Service_ID", "Service_Desc");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,DevoteeId,ServiceForDevoteeId,IsApproved,IsPaid,ApprovedDate,ApprovedBy,DateCreated,LastModified,LastModifiedBy,IsActive,ReceiptId")] Booking booking)
        {
            booking.DateCreated = DateTime.Now;
            booking.ApprovedBy = "Rajitha";
            booking.LastModified = DateTime.Now;
            booking.LastModifiedBy = "Rajitha";
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                BookingItem bookingItem = new BookingItem();
                bookingItem.BookingId = booking.BookingID;
                bookingItem.ServiceID = 6078;
                bookingItem.PriestAlloted = 1;
                bookingItem.PriestI = 1;
                bookingItem.PriestII = 7;
                bookingItem.PriestIII = 10;
                bookingItem.ServiceDate = DateTime.Now.Date;
                bookingItem.ServiceTimeID = 17;
                bookingItem.NoUnits = 1;
                bookingItem.Service_Fee = 51;
                _context.Add(bookingItem);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", booking.DevoteeId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", booking.DevoteeId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,DevoteeId,ServiceForDevoteeId,IsApproved,IsPaid,ApprovedDate,ApprovedBy,DateCreated,LastModified,LastModifiedBy,IsActive,ReceiptId")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", booking.DevoteeId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Devotee)
                .SingleOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.BookingID == id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
