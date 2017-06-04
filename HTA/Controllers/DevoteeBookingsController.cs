using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HTA.Models;
using HTA.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTA.Controllers
{
    public class DevoteeBookingsController : Controller
    {
        private readonly HTAContext _context;

        public DevoteeBookingsController(HTAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<BookingVM> BookingVMlist = new List<BookingVM>(); 
            var bookingsList = (from booking in _context.Bookings
                                join bookingItem in _context.BookingItems on booking.BookingID equals bookingItem.BookingId
select new { booking.DevoteeId, booking.ServiceForDevoteeId, bookingItem.ServiceID, bookingItem.ServiceDate, bookingItem.PriestI, bookingItem.PriestII, bookingItem.PriestIII, bookingItem.PriestAlloted, bookingItem.NoUnits, bookingItem.Service_Fee}).ToList();

            foreach (var item in bookingsList)
            {
                BookingVM objbvm = new BookingVM(); // ViewModel
                objbvm.DevoteeId = item.DevoteeId;
                objbvm.ServiceForDevoteeId = item.ServiceForDevoteeId;
                objbvm.ServiceID = item.ServiceID;
                objbvm.ServiceDate = item.ServiceDate;
                objbvm.PriestI = item.PriestI;
                objbvm.PriestII = item.PriestII;
                objbvm.PriestIII = item.PriestIII;
                objbvm.PriestAlloted = item.PriestAlloted;
                objbvm.NoUnits = item.NoUnits;
                objbvm.Service_Fee = item.Service_Fee;

                BookingVMlist.Add(objbvm);
            }


            return View(BookingVMlist);
            
        }

        // GET: DevoteeBookings/Create
        public IActionResult Create()
        {
            var DevoteeList = _context.Devotees.Where(d => d.Is_Active == true).OrderBy(d => d.First_Name).Select(d => new
            {
                Devotee_ID = d.Devotee_ID,
                First_Name = string.Format("{0} {1}", d.First_Name, d.Last_Name)
            }).ToList();
            DevoteeList.Insert(0, new { Devotee_ID = 0, First_Name = "--Select Devotee--" });
            ViewBag.DevoteeNames = new SelectList(DevoteeList, "Devotee_ID", "First_Name");

            var ServiceGroups= _context.ServiceGroups.Where(s => s.Is_Active == true).OrderBy(d => d.ServiceGroup_Name).Select(d => new
            {
                ServiceGroupID = d.ServiceGroup_ID,
                ServiceGroup_Name = string.Format("{0}", d.ServiceGroup_Name)
            }).ToList();
            ServiceGroups.Insert(0, new { ServiceGroupID = 0, ServiceGroup_Name = "--Select Service Group--" });
            ViewBag.ServiceGroupId = new SelectList(ServiceGroups, "ServiceGroupID", "ServiceGroup_Name");

            var ServiceNames = _context.Services.Where(s => s.Is_Active == true).OrderBy(d => d.Service_Desc).Select(d => new
            {
                ServiceID = d.Service_ID,
                Service_Desc = string.Format("{0}", d.Service_Desc)
            }).ToList();
            ServiceNames.Insert(0, new { ServiceID = 0, Service_Desc = "--Select Service--" });
            ViewBag.ServiceNames = new SelectList(ServiceNames, "ServiceID", "Service_Desc");

            return View();
        }

        // POST: DevoteeBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevoteeId,ServiceForDevoteeId,ServiceID,ServiceDate,ServiceTimeID,PriestI,PriestII,PriestIII,PriestAlloted,NoUnits,Service_Fee")] BookingVM bookingVM)
        {
            if (ModelState.IsValid)
            {
                Booking booking = new Booking();
                booking.DevoteeId = bookingVM.DevoteeId;
                booking.ServiceForDevoteeId = bookingVM.ServiceForDevoteeId;
                booking.IsPaid = false;
                booking.IsActive = true;
                booking.IsApproved = true;
                booking.DateCreated = DateTime.Now;
                booking.LastModified = DateTime.Now;
                booking.LastModifiedBy = "Rajitha";
                _context.Add(booking);
                await _context.SaveChangesAsync();

                BookingItem bookingItem = new BookingItem();
                bookingItem.BookingId = booking.BookingID;
                bookingItem.ServiceID = bookingVM.ServiceID;
                bookingItem.PriestAlloted = bookingVM.PriestAlloted;
                bookingItem.PriestI = bookingVM.PriestI;
                bookingItem.PriestII = bookingVM.PriestII;
                bookingItem.PriestIII = bookingVM.PriestIII;
                bookingItem.ServiceDate = bookingVM.ServiceDate;
                bookingItem.ServiceTimeID = bookingVM.ServiceTimeID;
                bookingItem.NoUnits = bookingVM.NoUnits;
                bookingItem.Service_Fee = bookingVM.Service_Fee;
                _context.Add(bookingItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            var DevoteeList = _context.Devotees.Where(d => d.Is_Active == true).OrderBy(d => d.First_Name).Select(d => new
            {
                Devotee_ID = d.Devotee_ID,
                First_Name = string.Format("{0} {1}", d.First_Name, d.Last_Name)
            }).ToList();
            DevoteeList.Insert(0, new { Devotee_ID = 0, First_Name = "--Select Devotee--" });
            ViewBag.DevoteeNames = new SelectList(DevoteeList, "Devotee_ID", "First_Name");
            ViewBag.ServiceGroupId = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_Name");
            ViewBag.ServiceNames = new SelectList(_context.Services, "Service_ID", "Service_Desc");

            return View(bookingVM);
        }


        public ActionResult FillServicesList(int serviceGroupId)
        {
            var services = _context.Services.Where(s => s.ServiceGroup_id == serviceGroupId);
            return Json(services);
        }

        
        public ActionResult GetServiceFee(int serviceId)
        {
            var service = _context.Services.Where(s => s.Service_ID == serviceId);
            return Json(service);
        }
    }
}