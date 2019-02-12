using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PainTracker.Controllers
{
    public class NewMedicineController : Controller
    {
        private List<Medicine> medicine;
        private NewMedicineGateway<Medicine> newMedicineGateway;

        // GET: NewMedicine
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewMedicine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewMedicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewMedicine/Create
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

        // GET: NewMedicine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewMedicine/Edit/5
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

        // GET: NewMedicine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewMedicine/Delete/5
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
        
        public ActionResult Upload(){
            //TODO implement Upload function
        }
    }
}