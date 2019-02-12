using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;
using ExploreCalifornia.Data;

namespace ExploreCalifornia.Controllers
{
    public class PatientController : Controller
    {
        private readonly ExploreCaliforniaContext _context;

        private PainDiaryGateway painGateway = new PainDiaryGateway();
        List<PainEntry> entryList;
        
        public PatientController(ExploreCaliforniaContext context)
        {
            _context = context;
        }

        // GET: PainDiaries Currently Controller only Retrieves data from db

        public ActionResult Index()
        {
            //Currently Retrieving a specific user information for testing
            PainDiary pain = painGateway.SelectById(1);

            //retrieve entries based on patient
            entryList = painGateway.retrieveEntries(pain.patientId);

            //Retrieve mood tied to Entries
            entryList = painGateway.retrieveMood(entryList);


            //Retrieve interference tied to Entries
            entryList = painGateway.retrieveInterference(entryList);
            //Returing list of PainEntries to view
            return View(entryList);
        }

        // GET: PainDiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiary = await _context.PainDiary
                .FirstOrDefaultAsync(m => m.patientId == id);
            if (painDiary == null)
            {
                return NotFound();
            }

            return View(painDiary);
        }

        // GET: PainDiaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PainDiaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("patientId")] PainDiary painDiary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painDiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painDiary);
        }

        // GET: PainDiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiary = await _context.PainDiary.FindAsync(id);
            if (painDiary == null)
            {
                return NotFound();
            }
            return View(painDiary);
        }

        // POST: PainDiaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("patientId")] PainDiary painDiary)
        {
            if (id != painDiary.patientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painDiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainDiaryExists(painDiary.patientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(painDiary);
        }

        // GET: PainDiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiary = await _context.PainDiary
                .FirstOrDefaultAsync(m => m.patientId == id);
            if (painDiary == null)
            {
                return NotFound();
            }

            return View(painDiary);
        }

        // POST: PainDiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painDiary = await _context.PainDiary.FindAsync(id);
            _context.PainDiary.Remove(painDiary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainDiaryExists(int id)
        {
            return _context.PainDiary.Any(e => e.patientId == id);
        }
    }
}
