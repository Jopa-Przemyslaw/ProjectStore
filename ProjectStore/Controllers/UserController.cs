using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectStore.Models;
using ProjectStore.Models.ViewsModels;
using ProjectStore.Models.ViewsModels.User;

namespace ProjectStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Message = "Welcome! It's your registration time.";
            RegisterVM user = new RegisterVM();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(RegisterVM user)
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                if (db.UserTables.Any(x => x.Username == user.userTable.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Register", user);
                }
                db.UserTables.Add(user.userTable);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("Login", new LoginVM());
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Message = "Welcome! It's your login time.";
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                var user = db.UserTables.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
                if (user != null)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Collection", "Collection");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong.");
                }
            }
            ModelState.Remove("Password");
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
    }
}