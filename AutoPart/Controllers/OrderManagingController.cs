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

namespace AutoPart.Controllers
{
    public class OrderManagingController : Controller
    {
        private MyContext db = new MyContext();

        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
            var customers = db.Customers.Where(c => c.Account == currentUser.Id).ToList();
            return View(customers);
        }
        public ActionResult ViewOrder(int id)
        {
            var orders = db.Orders.Include(p => p.Customer).Where(o => o.CustomerId == id).FirstOrDefault();
            return View(orders);
        }
        public ActionResult ViewOrderDetail(int id, float amount)
        {
            var orderDetails = db.OrderDetails.Include(p => p.Order).Include(p => p.Part).Where(o => o.OrderId == id).ToList();
            ViewBag.Amount = amount;
            return View(orderDetails);
        }
    }
}