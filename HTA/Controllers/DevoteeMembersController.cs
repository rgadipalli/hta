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
    public class DevoteeMembersController : Controller
    {
        private readonly HTAContext _context;

        public DevoteeMembersController(HTAContext context)
        {
            _context = context;    
        }

        // GET: DevoteeMembers
        public async Task<IActionResult> Index()
        {
            var hTAContext = _context.DevoteeMembers.Include(d => d.Devotee);
            return View(await hTAContext.ToListAsync());
        }

        // GET: DevoteeMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devoteeMember = await _context.DevoteeMembers
                .Include(d => d.Devotee)
                .SingleOrDefaultAsync(m => m.DevMem_ID == id);
            if (devoteeMember == null)
            {
                return NotFound();
            }

            return View(devoteeMember);
        }

        // GET: DevoteeMembers/Create
        public IActionResult Create()
        {
            ViewData["Devotee_ID"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID");
            return View();
        }

        // POST: DevoteeMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevMem_ID,Devotee_ID,Last_Name,First_Name,Middle_Name,Sex,DOB,Star_ID,Is_Active,Gothram_ID,CellPhone,Date_Created,Last_Modified,Who_Modified")] DevoteeMember devoteeMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devoteeMember);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Devotee_ID"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", devoteeMember.Devotee_ID);
            return View(devoteeMember);
        }

        // GET: DevoteeMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devoteeMember = await _context.DevoteeMembers.SingleOrDefaultAsync(m => m.DevMem_ID == id);
            if (devoteeMember == null)
            {
                return NotFound();
            }
            ViewData["Devotee_ID"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", devoteeMember.Devotee_ID);
            return View(devoteeMember);
        }

        // POST: DevoteeMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevMem_ID,Devotee_ID,Last_Name,First_Name,Middle_Name,Sex,DOB,Star_ID,Is_Active,Gothram_ID,CellPhone,Date_Created,Last_Modified,Who_Modified")] DevoteeMember devoteeMember)
        {
            if (id != devoteeMember.DevMem_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devoteeMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevoteeMemberExists(devoteeMember.DevMem_ID))
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
            ViewData["Devotee_ID"] = new SelectList(_context.Devotees, "Devotee_ID", "Devotee_ID", devoteeMember.Devotee_ID);
            return View(devoteeMember);
        }

        // GET: DevoteeMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devoteeMember = await _context.DevoteeMembers
                .Include(d => d.Devotee)
                .SingleOrDefaultAsync(m => m.DevMem_ID == id);
            if (devoteeMember == null)
            {
                return NotFound();
            }

            return View(devoteeMember);
        }

        // POST: DevoteeMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devoteeMember = await _context.DevoteeMembers.SingleOrDefaultAsync(m => m.DevMem_ID == id);
            _context.DevoteeMembers.Remove(devoteeMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DevoteeMemberExists(int id)
        {
            return _context.DevoteeMembers.Any(e => e.DevMem_ID == id);
        }
        
        public ActionResult FillServiceMemberList(int devoteeId)
        {
            var devoteeMembers = _context.DevoteeMembers.Where(d => d.Devotee_ID == devoteeId);
            return Json(devoteeMembers);
        }
    }
}
