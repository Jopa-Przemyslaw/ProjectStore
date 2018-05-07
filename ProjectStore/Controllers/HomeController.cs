using Microsoft.ApplicationInsights.Extensibility.Implementation;
using ProjectStore.Models;
using ProjectStore.Models.ViewsModels;
using ProjectStore.Models.ViewsModels.Collection;
using ProjectStore.Models.ViewsModels.Home;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectStore.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Here are short informations about us.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Here are all the informations and contact to our stores.";

            return View();
        }
        [Authorize]
        public ActionResult Customers()
        {
            ViewBag.Message = "Registered customeres list.";
            CustomersVM customers = new CustomersVM();
            return View("Customers", customers);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Details about customer.";
            var db = new UserDBEntities();
            UserTable user = db.UserTables.Where(u => u.UserID == id).Single();
            UserDetailsVM userDetailsVM = new UserDetailsVM(user);
            return View("Details", userDetailsVM);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            UserDBEntities db = new UserDBEntities();
            UserTable user = db.UserTables.Where(u => u.UserID == id).Single();
            UserEditVM userEditVM = new UserEditVM(user);
            return View("Edit", userEditVM);
        }
        [HttpPost]
        public ActionResult Edit(UserEditVM user)
        {
            UserDBEntities db = new UserDBEntities();
            UserTable userToUpdate = db.UserTables.Where(u => u.Username == user.Username).Single();
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.IsAdmin = user.IsAdmin;
            userToUpdate.Age = user.Age;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            db.SaveChanges();
            return Customers();
        }
        [Authorize]
        public ActionResult Remove(int id)
        {
            UserDBEntities db = new UserDBEntities();
            UserTable user = db.UserTables.Where(u => u.UserID == id).Single();
            if (user != null)
                db.UserTables.Remove(user);
            db.SaveChanges();
            return Customers();
        }
    }
}