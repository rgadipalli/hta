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
    public class ServicesController : Controller
    {
        private readonly HTAContext _context;

        public ServicesController(HTAContext context)
        {
            _context = context;    
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var hTAContext = _context.Services.Include(s => s.ServiceGroup);
            return View(await hTAContext.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.ServiceGroup)
                .SingleOrDefaultAsync(m => m.Service_ID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["ServiceGroup_id"] = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_ID");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Service_ID,Service_Desc,Fee,Is_Outside,Is_Web_Avail,Is_Quick,CommitteeType_ID,Is_Priest,Is_IT_Exempt,Is_Active,Date_Created,Last_Modified,Who_Modified,Notes,EmailReceipt,ToEmailAddress,EmailSubject,ServiceGroup_id")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ServiceGroup_id"] = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_ID", service.ServiceGroup_id);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.SingleOrDefaultAsync(m => m.Service_ID == id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["ServiceGroup_id"] = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_ID", service.ServiceGroup_id);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Service_ID,Service_Desc,Fee,Is_Outside,Is_Web_Avail,Is_Quick,CommitteeType_ID,Is_Priest,Is_IT_Exempt,Is_Active,Date_Created,Last_Modified,Who_Modified,Notes,EmailReceipt,ToEmailAddress,EmailSubject,ServiceGroup_id")] Service service)
        {
            if (id != service.Service_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Service_ID))
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
            ViewData["ServiceGroup_id"] = new SelectList(_context.ServiceGroups, "ServiceGroup_ID", "ServiceGroup_ID", service.ServiceGroup_id);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.ServiceGroup)
                .SingleOrDefaultAsync(m => m.Service_ID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.SingleOrDefaultAsync(m => m.Service_ID == id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Service_ID == id);
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
