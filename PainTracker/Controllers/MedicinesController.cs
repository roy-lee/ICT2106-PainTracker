using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Http;
using MedicineIntake.Data;

namespace ExploreCalifornia.Controllers
{
    public class MedicinesController : Controller
    {
        private NewMedicineGateway newMedicineGateway = new NewMedicineGateway();

        // GET: Medicines
        public ActionResult Index()
        {
            return View(newMedicineGateway.SelectAll());
        }

     
        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //var med = new Medicine
                //{
                //    MedName = Request.Form["Name"],
                //    MedDescription = Request.Form["Description"],
                //    MedType = Request.Form["MedType"],
                //    IssuedDate = Convert.ToDateTime(Request.Form["Price"]),
                //    ExpiryDate = Convert.ToDateTime(Request.Form["Rating"]),
                //    //IncludesMeals = Convert.ToBoolean(Request.Form["IncludesMeals"])
                //};
                

                //newMedicineGateway.Insert(med);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicine medicine = newMedicineGateway.SelectById(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //Tour tour = new Tour
                //{
                //    Name = Request.Form["Name"],
                //    Description = Request.Form["Description"],
                //    Length = Convert.ToInt32(Request.Form["Length"]),
                //    Price = Convert.ToDecimal(Request.Form["Price"]),
                //    Rating = Request.Form["Rating"],
                //    //IncludesMeals = Convert.ToBoolesan(Request.Form["IncludesMeals"])
                //};

                //newMedicineGateway.Insert(tour);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicine medicine = newMedicineGateway.SelectById(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newMedicineGateway.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
