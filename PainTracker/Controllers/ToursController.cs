using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTracker.Models;
using PainTracker.Data;

namespace PainTracker.Controllers
{
    public class ToursController : Controller
    {
        private TourGateway tourGateway = new TourGateway();
        
        // GET: Tours
        public IActionResult Index()
        {
            return View(tourGateway.SelectAll());
        }

        // Get: Tours/Confirm
        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tour tour = tourGateway.SelectById(id);
            //await _context.Tours.FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tour tour = tourGateway.SelectById(id);
            //await _context.Tours.FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourGateway.Insert(tour);
                tourGateway.Save();
                var newlyCreatedId = tour.Id;
                return RedirectToAction(nameof(Confirm), new { id = newlyCreatedId });
            }
            return View(tour);
        }

        // GET: Tours/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = tourGateway.SelectById(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tourGateway.Update(tour);
                    tourGateway.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (tourGateway.SelectById(tour.Id) == null)
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
            return View(tour);
        }

        // GET: Tours/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = tourGateway.SelectById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tour = tourGateway.SelectById(id);
            tourGateway.Delete(id);
            tourGateway.Save();
            return RedirectToAction(nameof(Index));
        }
    }

    public class TourGateway : ITourGateway
    {
        internal PainTrackerContext db = new PainTrackerContext();

        public IEnumerable<Tour> SelectAll()
        {
            Console.WriteLine("Interface gatway: public IEnumerable<Tour> SelectAll()");
            return db.Tour.ToList();
        }

        public Tour SelectById(int? id)
        {
            Tour tour = db.Tour.Find(id);
            return tour;
        }

        public void Insert(Tour tour)
        {
            db.Tour.Add(tour);
            Save();
        }

        public void Update(Tour tour)
        {
            db.Tour.Update(tour);
            Save();
        }

        public Tour Delete(int? id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
            Save();
            return tour;
        }
        
        public void Save()
        {
            db.SaveChanges();
        }
        
    }
}
