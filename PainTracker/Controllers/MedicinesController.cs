using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PainTracker.Data;
using PainTracker.Models;
using System.Text;

namespace PainTracker.Controllers
{
    public class MedicinesController : Controller
    {
        private DataGateway<Medicine> medicineGateway = new DataGateway<Medicine>();
        private DataGateway<Image> imageGateway = new DataGateway<Image>();

        // GET: Medicines
        public ActionResult Index()
        {
            return View(medicineGateway.SelectAll());
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
                Medicine med = new Medicine
                {
                    MedName = Request.Form["medicine.MedName"],
                    MedDescription = Request.Form["medicine.MedDescription"],
                    MedType = Request.Form["medicine.MedType"],
                };

                medicineGateway.Insert(med);                
                Image image = new Image
                {
                    ImgID = med.MedID,
                    MedImage = Encoding.BigEndianUnicode.GetBytes(Request.Form["img.MedImage"]),
                };

                imageGateway.Insert(image);
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

            Medicine medicine = medicineGateway.SelectById(id);
           
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
        public ActionResult Edit(int id,IFormCollection collection)
        {            
            Medicine medicine = medicineGateway.SelectById(id);
            medicine.MedName = Request.Form["MedName"];
            medicine.MedDescription = Request.Form["MedDescription"];
            medicine.MedType = Request.Form["MedType"];
            medicineGateway.Update(medicine);
            return RedirectToAction(nameof(Index));            
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicine medicine = medicineGateway.SelectById(id);            
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
            medicineGateway.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
