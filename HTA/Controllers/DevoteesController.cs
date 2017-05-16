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
    public class DevoteesController : Controller
    {
        private readonly HTAContext _context;

        public DevoteesController(HTAContext context)
        {
            _context = context;    
        }

        // GET: Devotees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Devotee.ToListAsync());
        }

        // GET: Devotees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devotee = await _context.Devotee
                .SingleOrDefaultAsync(m => m.Devotee_ID == id);
            if (devotee == null)
            {
                return NotFound();
            }

            return View(devotee);
        }

        // GET: Devotees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devotees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Devotee_ID,LoginEmail,Password,TemporaryPassord,Home_Phone,Last_Name,First_Name,Middle_Name,Is_Company,Company_Name,Address_1,Address_2,City,StateID,Zip,Work_Phone,Work_Phone_Ext,Cell_Phone,Fax,Sex,DOB,Wedding_Date,MemberType_ID,Gothram_ID,Star_ID,Is_Active,Is_Mailing,Is_Emailing,Is_ProfileComplete,Last_Modified,Who_Modified,Date_Created,Last_LoggedIn")] Devotee devotee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devotee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(devotee);
        }

        // GET: Devotees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devotee = await _context.Devotee.SingleOrDefaultAsync(m => m.Devotee_ID == id);
            if (devotee == null)
            {
                return NotFound();
            }
            return View(devotee);
        }

        // POST: Devotees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Devotee_ID,LoginEmail,Password,TemporaryPassord,Home_Phone,Last_Name,First_Name,Middle_Name,Is_Company,Company_Name,Address_1,Address_2,City,StateID,Zip,Work_Phone,Work_Phone_Ext,Cell_Phone,Fax,Sex,DOB,Wedding_Date,MemberType_ID,Gothram_ID,Star_ID,Is_Active,Is_Mailing,Is_Emailing,Is_ProfileComplete,Last_Modified,Who_Modified,Date_Created,Last_LoggedIn")] Devotee devotee)
        {
            if (id != devotee.Devotee_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devotee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevoteeExists(devotee.Devotee_ID))
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
            return View(devotee);
        }

        // GET: Devotees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devotee = await _context.Devotee
                .SingleOrDefaultAsync(m => m.Devotee_ID == id);
            if (devotee == null)
            {
                return NotFound();
            }

            return View(devotee);
        }

        // POST: Devotees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devotee = await _context.Devotee.SingleOrDefaultAsync(m => m.Devotee_ID == id);
            _context.Devotee.Remove(devotee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DevoteeExists(int id)
        {
            return _context.Devotee.Any(e => e.Devotee_ID == id);
        }
    }
}
