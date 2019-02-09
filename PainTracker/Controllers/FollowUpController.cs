using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PainTracker.Data.FollowUp;
using PainTracker.Models.FollowUpModels;
using PainTracker.Models.FollowUpModels.States;

namespace PainTracker.Controllers
{
    public class FollowUpController : Controller
    {
        // Temporary List to simulate database.
        static List<FollowUpDTO> FollowUpList = new List<FollowUpDTO>();

        private FollowUpDBMapper followUpDbMapper;

        public FollowUpController(IMapper mapper)
        {
            followUpDbMapper = new FollowUpDBMapper(mapper);
            System.Diagnostics.Debug.WriteLine("FollowUpController created");
        }

        // GET: FollowUp
        public ActionResult Index()
        {
            for (int i = 1; i <= 10; i++)
            {
                FollowUpDTO insertFollowUps = new FollowUpDTO();
                insertFollowUps.FollowUpId = 1;
                FollowUpList.Add(insertFollowUps);
            }

            FollowUp fuvm = new FollowUp();
            fuvm.State = new PendingAdviceState();
            followUpDbMapper.Insert(fuvm);
            followUpDbMapper.Save();

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