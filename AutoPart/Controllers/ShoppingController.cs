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
            int pageSize = 8;
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
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == id).ToList();
            ViewBag.CarBrandId = id;
            foreach (var part in parts)
            {
                ViewBag.CarBrand = part.CarBrand.CarBrandName;
            }
            var finalList = parts.ToPagedList(pageIndex, pageSize);
            return View(finalList);
        }

        public ActionResult FilterByCategory(int id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == id).ToList();
            ViewBag.CategoryId = id;
            foreach (var part in parts)
            {
                ViewBag.Category = part.Category.Name;
            }
            var finalList = parts.ToPagedList(pageIndex, pageSize);
            return View(finalList);
        }

        public ActionResult Arrange(string arr, int? page)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (arr == "name")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderBy(p => p.Name).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Name By Alphabet";
                ViewBag.Action = arr;
                return View(finalList);
            }
            else if (arr == "price")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderBy(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From Low To High";
                ViewBag.Action = arr;
                return View(finalList);
            }
            else
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).OrderByDescending(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From High To Low";
                ViewBag.Action = arr;
                return View(finalList);
            }
        }

        public ActionResult ArrangeByCarBrand(string arr, int? page, int carBrandId)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (arr == "name")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == carBrandId).OrderBy(p => p.Name).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Name By Alphabet";
                ViewBag.Action = arr;
                ViewBag.CarBrandId = carBrandId;
                return View(finalList);
            }
            else if (arr == "price")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == carBrandId).OrderBy(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From Low To High";
                ViewBag.Action = arr;
                ViewBag.CarBrandId = carBrandId;
                return View(finalList);
            }
            else
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CarBrandId == carBrandId).OrderByDescending(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From High To Low";
                ViewBag.Action = arr;
                ViewBag.CarBrandId = carBrandId;
                return View(finalList);
            }
        }

        public ActionResult ArrangeByCategory(string arr, int? page, int categoryId)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (arr == "name")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Name By Alphabet";
                ViewBag.Action = arr;
                ViewBag.CategoryId = categoryId;
                return View(finalList);
            }
            else if (arr == "price")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == categoryId).OrderBy(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From Low To High";
                ViewBag.Action = arr;
                ViewBag.CategoryId = categoryId;
                return View(finalList);
            }
            else
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.CategoryId == categoryId).OrderByDescending(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From High To Low";
                ViewBag.Action = arr;
                ViewBag.CategoryId = categoryId;
                return View(finalList);
            }
        }

        public ActionResult SearchByName(string partName, int? page)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var parts = from p in db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier) where p.Name.Contains(partName) select p;
            var finalList = parts.ToList().ToPagedList(pageIndex, pageSize); ;
            foreach (var part in parts)
            {
                ViewBag.PartCategory = part.Category.Name;
            }
            ViewBag.PartName = partName;
            return View(finalList);
        }

        public ActionResult ArrangeByName(string arr, int? page, string partName)
        {
            int pageSize = 4;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (arr == "name")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.Name.Contains(partName)).OrderBy(p => p.Name).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Name By Alphabet";
                ViewBag.Action = arr;
                ViewBag.PartName = partName;
                return View(finalList);
            }
            else if (arr == "price")
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.Name.Contains(partName)).OrderBy(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From Low To High";
                ViewBag.Action = arr;
                ViewBag.PartName = partName;
                return View(finalList);
            }
            else
            {
                var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier).Where(p => p.Name.Contains(partName)).OrderByDescending(p => p.UnitPrice).ToList();
                var finalList = parts.ToPagedList(pageIndex, pageSize);
                ViewBag.ArrangeType = "Price From High To Low";
                ViewBag.Action = arr;
                ViewBag.PartName = partName;
                return View(finalList);
            }
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

        public PartialViewResult PartialSearchBar()
        {
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            var carBrands = db.CarBrands.ToList();
            ViewBag.CarBrands = carBrands;
            return PartialView();
        }
    }
}
