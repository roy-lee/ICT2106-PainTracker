using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PainTracker.Models;

namespace PainTracker.Controllers
{
    public class FollowUpsController : Controller
    {
        // Temporary List to simulate database.
        static List<FollowUps> FollowUpList = new List<FollowUps>();

        // GET: FollowUps
        public ActionResult Index()
        {
            for (int i = 1; i <= 10; i++)
            {
                FollowUpList.Add(new FollowUps(i));
            }

            return View(FollowUpList);
        }

        // GET: FollowUps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FollowUps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FollowUps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FollowUps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FollowUps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FollowUps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FollowUps/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}