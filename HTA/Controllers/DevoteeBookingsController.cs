using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HTA.Models;
using HTA.ViewModels;
using Microsoft.EntityFrameworkCore;

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
    }
}