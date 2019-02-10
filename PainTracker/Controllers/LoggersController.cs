using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTracker.Models;

namespace PainTracker.Controllers
{
    public class LoggersController : Controller
    {
        private readonly MedicineIntakeContext _context;

        public LoggersController(MedicineIntakeContext context)
        {
            _context = context;
        }

        // GET: Loggers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logger.ToListAsync());
        }

        // GET: Loggers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logger = await _context.Logger
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (logger == null)
            {
                return NotFound();
            }

            return View(logger);
        }

        // GET: Loggers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loggers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,IssuedDate,ExpiryDate,Dosage")] Logger logger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logger);
        }

        // GET: Loggers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logger = await _context.Logger.FindAsync(id);
            if (logger == null)
            {
                return NotFound();
            }
            return View(logger);
        }

        // POST: Loggers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogID,IssuedDate,ExpiryDate,Dosage")] Logger logger)
        {
            if (id != logger.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoggerExists(logger.LogID))
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
            return View(logger);
        }

        // GET: Loggers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logger = await _context.Logger
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (logger == null)
            {
                return NotFound();
            }

            return View(logger);
        }

        // POST: Loggers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logger = await _context.Logger.FindAsync(id);
            _context.Logger.Remove(logger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoggerExists(int id)
        {
            return _context.Logger.Any(e => e.LogID == id);
        }
    }
}
