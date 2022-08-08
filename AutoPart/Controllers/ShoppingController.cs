using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoPart.Models;
using PagedList;

namespace AutoPart.Controllers
{
    public class ShoppingController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Shopping
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).ToList();
            var finalList = parts.ToPagedList(pageIndex, pageSize);
            return View(finalList);
        }

        public ActionResult FilterByCarBrand(int id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == id).ToList();
            var finalList = parts.ToPagedList(pageIndex, pageSize);
            return View(finalList);
        }

        public ActionResult FilterByCategory(int id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == id).ToList();
            var finalList = parts.ToPagedList(pageIndex, pageSize);
            return View(finalList);
        }

        public ActionResult Arrange(string arr, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (arr == "name")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderBy(p => p.Name);
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                return View(finalList);
            }
            else if (arr == "price")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderBy(p => p.UnitPrice);
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                return View(finalList);
            }
            else
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderByDescending(p => p.UnitPrice);
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                return View(finalList);
            }
        }

        public ActionResult SearchByName(string partName)
        {
            var parts = from p in db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier) where p.Name.Contains(partName) select p;
            return View(parts.ToList());
        }

        // GET: Shopping/Details/5
        public ActionResult Details(int? id, string supplier, string carBrand, string manufacturer, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            var similarParts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == part.CategoryId);
            ViewBag.SimilarParts = similarParts.ToList();
            ViewBag.Supplier = supplier;
            ViewBag.CarBrand = carBrand;
            ViewBag.manufacturer = manufacturer;
            ViewBag.Category = category;
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        public ActionResult SimilarPartsByManufacturer(int id, string supplier, string carBrand, string manufacturer, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            var similarPartsByManufacturer = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.ManufacturerId == part.ManufacturerId && p.CategoryId == part.CategoryId);
            ViewBag.SimilarPartsByManufacturer = similarPartsByManufacturer.ToList();
            ViewBag.Supplier = supplier;
            ViewBag.CarBrand = carBrand;
            ViewBag.Manufacturer = manufacturer;
            ViewBag.Category = category;
            return View(part);
        }

        public ActionResult SimilarPartsByCarBrand(int id, string supplier, string carBrand, string manufacturer, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            var similarPartsByCarBrand = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == part.CarBrandId && p.CategoryId == part.CategoryId);
            ViewBag.SimilarPartsByCarBrand = similarPartsByCarBrand.ToList();
            ViewBag.Supplier = supplier;
            ViewBag.CarBrand = carBrand;
            ViewBag.Manufacturer = manufacturer;
            ViewBag.Category = category;
            return View(part);
        }

        public ActionResult Compare(int basePartId, string basePartSupplier, string basePartCarBrand, string basePartManufacturer, string basePartCategory, int id, string supplier, string carBrand, string manufacturer, string category)
        {
            if (id == null && basePartId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var basePart = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).FirstOrDefault(p => p.Id == basePartId);
            ViewBag.BasePartSupplier = basePartSupplier;
            ViewBag.BasePartCarBrand = basePartCarBrand;
            ViewBag.BasePartManufacturer = basePartManufacturer;
            ViewBag.BasePartCategory = basePartCategory;
            var similarParts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == basePart.CategoryId);
            ViewBag.SimilarParts = similarParts.ToList();
            var part = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).FirstOrDefault(p => p.Id == id);
            ViewBag.Part = part;
            ViewBag.Supplier = supplier;
            ViewBag.CarBrand = carBrand;
            ViewBag.Manufacturer = manufacturer;
            ViewBag.Category = category;
            return View(basePart);
        }
    }
}
