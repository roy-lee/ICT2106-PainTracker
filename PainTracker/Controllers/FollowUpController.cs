using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PainTracker.Data.FollowUp;
using PainTracker.Models.FollowUpModels;

namespace PainTracker.Controllers
{
    public class FollowUpController : Controller
    {

        private FollowUpDBMapper followUpDbMapper;

        // controller should receive the mapper as parameter, pass the mapper as a reference instead of new()
        public FollowUpController(FollowUpDBMapper mapper)
        {
            followUpDbMapper = mapper;
            System.Diagnostics.Debug.WriteLine("FollowUpController created");
        }

        // GET: FollowUp
        public ActionResult Index()
        {

            IEnumerable<FollowUp> FollowUpList = followUpDbMapper.SelectAll();

            return View(FollowUpList);
        }

        // GET: FollowUps/Details/5
        public ActionResult Details(int id)
        {
            FollowUp resultFollowUp = followUpDbMapper.SelectById(id);
//            System.Diagnostics.Debug.WriteLine("FollowUpController.Details() - resultfollowUp.QuestionId.Count = " + resultFollowUp.QuestionId.Count);
            return View(resultFollowUp);
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