using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTracker.Data.FollowUp;
using PainTracker.Models;

namespace PainTracker.Controllers
{
    public class PainDairyDTOesController : Controller
    {
        private readonly TourContext _context;

        public PainDairyDTOesController(TourContext context)
        {
            _context = context;
        }

        // GET: PainDairyDTOes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PainDairyDTO.Include(pdto => pdto.FollowUpDTO).ToListAsync());
        }

        // GET: PainDairyDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine("id not null");
            var painDairyDTO = await _context.PainDairyDTO.Include(pdto => pdto.FollowUpDTO)
                .FirstOrDefaultAsync(m => m.PainDairyId == id);
            System.Diagnostics.Debug.WriteLine("async over");
            if (painDairyDTO == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine("returning pdid: " + painDairyDTO.PainDairyId);
            if (painDairyDTO.FollowUpDTO == null)
            {
                System.Diagnostics.Debug.WriteLine("null");
            }
            return View(painDairyDTO);
        }

        // GET: PainDairyDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PainDairyDTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PainDairyId")] PainDairyDTO painDairyDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painDairyDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painDairyDTO);
        }

        // GET: PainDairyDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDairyDTO = await _context.PainDairyDTO.FindAsync(id);
            if (painDairyDTO == null)
            {
                return NotFound();
            }
            return View(painDairyDTO);
        }

        // POST: PainDairyDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PainDairyId")] PainDairyDTO painDairyDTO)
        {
            if (id != painDairyDTO.PainDairyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painDairyDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainDairyDTOExists(painDairyDTO.PainDairyId))
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
            return View(painDairyDTO);
        }

        // GET: PainDairyDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDairyDTO = await _context.PainDairyDTO
                .FirstOrDefaultAsync(m => m.PainDairyId == id);
            if (painDairyDTO == null)
            {
                return NotFound();
            }

            return View(painDairyDTO);
        }

        // POST: PainDairyDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painDairyDTO = await _context.PainDairyDTO.FindAsync(id);
            _context.PainDairyDTO.Remove(painDairyDTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainDairyDTOExists(int id)
        {
            return _context.PainDairyDTO.Any(e => e.PainDairyId == id);
        }
    }
}
