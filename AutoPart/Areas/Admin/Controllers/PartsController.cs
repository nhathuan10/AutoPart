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
    [Authorize(Roles = "Admin")]
    public class PartsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/Parts
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier);
            return View(parts.ToList());
        }

        // GET: Admin/Parts/Details/5
        public ActionResult Details(int? id, string carBrand, string manufacturer, string supplier, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            ViewBag.CarBrand = carBrand;
            ViewBag.Manufacturer = manufacturer;
            ViewBag.Supplier = supplier;
            ViewBag.Category = category;
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // GET: Admin/Parts/Create
        public ActionResult Create()
        {
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "CarBrandName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Admin/Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,CarBrandId,SupplierId,ManufacturerId,CategoryId,CarName,UnitPrice,Description,Condition,Image,ImageSub1,ImageSub2,QuantityinStock")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "CarBrandName", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", part.SupplierId);
            return View(part);
        }

        // GET: Admin/Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "CarBrandName", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", part.SupplierId);
            return View(part);
        }

        // POST: Admin/Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,CarBrandId,SupplierId,ManufacturerId,CategoryId,CarName,UnitPrice,Description,Condition,Image,ImageSub1,ImageSub2,QuantityinStock")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "CarBrandName", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", part.SupplierId);
            return View(part);
        }

        // GET: Admin/Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Admin/Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
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
