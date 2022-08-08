using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using AutoPart.Models;

namespace AutoPart.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        // GET: Admin/Role
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddUserToRole()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = from u in context.Users select u;
                ViewBag.Username = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id}).ToList();
                var roles = from r in context.Roles select r;
                ViewBag.Name = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddUserToRole(string UserName, string Name)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(UserName, Name);
            ViewBag.Name = UserName;
            ViewBag.Role = Name;
            return View("AssigningConfirmed");
        }
    }
}