using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoPart.Models;

namespace AutoPart.Areas.Admin.Controllers
{
    public class CarBrandsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/CarBrands
        public ActionResult Index()
        {
            return View(db.CarBrands.ToList());
        }

        // GET: Admin/CarBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarBrand carBrand = db.CarBrands.Find(id);
            if (carBrand == null)
            {
                return HttpNotFound();
            }
            return View(carBrand);
        }

        // GET: Admin/CarBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarBrandName,Country")] CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                db.CarBrands.Add(carBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carBrand);
        }

        // GET: Admin/CarBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarBrand carBrand = db.CarBrands.Find(id);
            if (carBrand == null)
            {
                return HttpNotFound();
            }
            return View(carBrand);
        }

        // POST: Admin/CarBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarBrandName,Country")] CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carBrand);
        }

        // GET: Admin/CarBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarBrand carBrand = db.CarBrands.Find(id);
            if (carBrand == null)
            {
                return HttpNotFound();
            }
            return View(carBrand);
        }

        // POST: Admin/CarBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarBrand carBrand = db.CarBrands.Find(id);
            db.CarBrands.Remove(carBrand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
