using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainTracker.Data.FollowUp;
using PainTracker.Models;

namespace PainTracker.Controllers
{
    // Driver Controller
    public class PainDairyDriverController : Controller
    {
        private readonly TourContext _context;

        public PainDairyDriverController(TourContext context)
        {
            _context = context;
        }

        // GET: PainDairyStub
        public async Task<IActionResult> Index()
        {
            return View(await _context.PainDairyStub.Include(pdto => pdto.FollowUpDTO).ToListAsync());
        }

        // GET: PainDairyStub/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine("id not null");
            var painDairyDTO = await _context.PainDairyStub.Include(pdto => pdto.FollowUpDTO)
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

        // GET: PainDairyStub/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PainDairyStub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PainDairyId")] PainDairyStub painDairStub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painDairStub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painDairStub);
        }

        // GET: PainDairyStub/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDairyDTO = await _context.PainDairyStub.FindAsync(id);
            if (painDairyDTO == null)
            {
                return NotFound();
            }
            return View(painDairyDTO);
        }

        // POST: PainDairyStub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PainDairyId")] PainDairyStub painDairyStub)
        {
            if (id != painDairyStub.PainDairyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painDairyStub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainDairyDTOExists(painDairyStub.PainDairyId))
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
            return View(painDairyStub);
        }

        // GET: PainDairyStub/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDairyDTO = await _context.PainDairyStub
                .FirstOrDefaultAsync(m => m.PainDairyId == id);
            if (painDairyDTO == null)
            {
                return NotFound();
            }

            return View(painDairyDTO);
        }

        // POST: PainDairyStub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painDairyDTO = await _context.PainDairyStub.FindAsync(id);
            _context.PainDairyStub.Remove(painDairyDTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainDairyDTOExists(int id)
        {
            return _context.PainDairyStub.Any(e => e.PainDairyId == id);
        }
    }
}
