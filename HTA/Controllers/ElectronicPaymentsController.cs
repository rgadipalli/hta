using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace HTA.Controllers
{
    public class ElectronicPaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = 1000;
            myCharge.Currency = "usd";

            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Test Charge";
            myCharge.SourceTokenOrExistingSourceId = stripeToken;
            myCharge.Capture = true;

            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);

            return View();
        }
    }
}