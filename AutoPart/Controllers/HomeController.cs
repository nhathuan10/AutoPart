using AutoPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoPart.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db = new MyContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact([Bind(Include = "Id, Name, Email, Subject, MessageContent")] Message mess)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(mess);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(mess);
        }
    }
}