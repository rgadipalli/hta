using HTA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTA.Controllers
{
    public class ElectronicPaymentsController : Controller
    {
        private readonly HTAContext _context;

        public ElectronicPaymentsController(HTAContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int bookingId)
        {
            if (bookingId > 0)
            {
                var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.BookingID == bookingId);
                var bookingItem = await _context.BookingItems.SingleOrDefaultAsync(bi => bi.BookingId == bookingId);
                var devMember = await _context.DevoteeMembers.SingleOrDefaultAsync(d => d.DevMem_ID == booking.DevoteeMemID);
                var devotee = await _context.Devotees.SingleOrDefaultAsync(d => d.Devotee_ID == booking.DevoteeId);
                var service = await _context.Services.SingleOrDefaultAsync(s => s.Service_ID == bookingItem.ServiceID);

                var devoteeAndServiceDetails = new Dictionary<string, string>
                {
                    ["BookingId"] = booking.BookingID.ToString(),
                    ["ServiceForDevotee"] = devMember.First_Name + " " + devMember.Last_Name,
                    ["DevoteeEmail"] = string.IsNullOrEmpty(devotee.LoginEmail)
                        ? "rajitha.gadipalli@gmail.com"
                        : devotee.LoginEmail,
                    ["ServiceName"] = service.Service_Desc,
                    ["ServiceFee"] = bookingItem.Service_Fee.ToString("c")
                };
                ViewBag.DevoteeAndServiceDetails = devoteeAndServiceDetails;
            }
            else
            {
                var devoteeAndServiceDetails = new Dictionary<string, string>
                {
                    ["BookingId"] = 123.ToString(),
                    ["ServiceForDevotee"] = "Test Test",
                    ["DevoteeEmail"] = "Test@Test.com",
                    ["ServiceName"] = "Archana",
                    ["ServiceFee"] = 120.00.ToString("c")
                };
                ViewBag.DevoteeAndServiceDetails = devoteeAndServiceDetails;
            }
            

            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail, string serviceName, string serviceFee)
        {
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = 120;
            myCharge.Currency = "usd";

            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Test";
            myCharge.SourceTokenOrExistingSourceId = stripeToken;
            myCharge.Capture = true;

            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);

            return View();
        }
    }
}
