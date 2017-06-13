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
    public class ServiceGroupsController : Controller
    {
        private readonly HTAContext _context;

        public ServiceGroupsController(HTAContext context)
        {
            _context = context;    
        }

        // GET: ServiceGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceGroups.ToListAsync());
        }

        // GET: ServiceGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceGroup = await _context.ServiceGroups
                .SingleOrDefaultAsync(m => m.ServiceGroup_ID == id);
            if (serviceGroup == null)
            {
                return NotFound();
            }

            return View(serviceGroup);
        }

        // GET: ServiceGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceGroup_ID,ServiceGroup_Name,Date_Created,Last_Modified,Who_Modified,Is_Active")] ServiceGroup serviceGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviceGroup);
        }

        // GET: ServiceGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceGroup = await _context.ServiceGroups.SingleOrDefaultAsync(m => m.ServiceGroup_ID == id);
            if (serviceGroup == null)
            {
                return NotFound();
            }
            return View(serviceGroup);
        }

        // POST: ServiceGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceGroup_ID,ServiceGroup_Name,Date_Created,Last_Modified,Who_Modified,Is_Active")] ServiceGroup serviceGroup)
        {
            if (id != serviceGroup.ServiceGroup_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceGroupExists(serviceGroup.ServiceGroup_ID))
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
            return View(serviceGroup);
        }

        // GET: ServiceGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceGroup = await _context.ServiceGroups
                .SingleOrDefaultAsync(m => m.ServiceGroup_ID == id);
            if (serviceGroup == null)
            {
                return NotFound();
            }

            return View(serviceGroup);
        }

        // POST: ServiceGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceGroup = await _context.ServiceGroups.SingleOrDefaultAsync(m => m.ServiceGroup_ID == id);
            _context.ServiceGroups.Remove(serviceGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServiceGroupExists(int id)
        {
            return _context.ServiceGroups.Any(e => e.ServiceGroup_ID == id);
        }
    }
}
