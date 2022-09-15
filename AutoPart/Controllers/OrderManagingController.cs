using AutoPart.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoPart.Models;
using System.Net;

namespace AutoPart.Controllers
{
    public class OrderManagingController : Controller
    {
        private MyContext db = new MyContext();

        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
            var customers = db.Customers.Where(c => c.Email == currentUser.Email).ToList();
            return View(customers);
        }

        public ActionResult ViewOrder(int id)
        {
            var orders = db.Orders.Include(p => p.Customer).Where(o => o.CustomerId == id);
            return View(orders);
        }

        public ActionResult ViewOrderDetail(int id, float amount)
        {
            var orderDetails = db.OrderDetails.Include(p => p.Order).Include(p => p.Part).Where(o => o.OrderId == id).ToList();
            ViewBag.Amount = amount;
            return View(orderDetails);
        }

        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.Include(o => o.Customer).Where(o => o.Id == id).FirstOrDefault();
            ViewBag.OrderId = id;
            ViewBag.OrderCustomerName = order.Customer.Name;
            db.Orders.Remove(order);
            db.SaveChanges();
            return View();
        }

        public ActionResult CreateCustomer()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser curentUser = UserManager.FindById(User.Identity.GetUserId());
            string userEmail = curentUser.Email;
            ViewBag.UserEmail = userEmail;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "Id,Name,Address,City,State,Email,Phone")] Customer customer, string email2)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserEmail = email2;
            return View(customer);
        }

        public ActionResult EditCustomer(int? id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser curentUser = UserManager.FindById(User.Identity.GetUserId());
            string userEmail = curentUser.Email;
            ViewBag.UserEmail = userEmail;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id,Name,Address,City,State,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}