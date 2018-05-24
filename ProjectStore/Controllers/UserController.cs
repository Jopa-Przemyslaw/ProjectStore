using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ProjectStore.DAL;
using ProjectStore.Models.ViewsModels.User;

namespace ProjectStore.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Register new user.
        /// </summary>
        /// <returns>Action Register.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Message = "Welcome! It's your registration time.";
            RegisterVM user = new RegisterVM();
            return View(user);
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="user">User of type RegisterVM.</param>
        /// <returns>Login View.</returns>
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

        /// <summary>
        /// Login user.
        /// </summary>
        /// <returns>Action Login.</returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Message = "Welcome! It's your login time.";
            return View();
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="login">User of type LoginVM.</param>
        /// <returns>Login View.</returns>
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

        /// <summary>
        /// Logout user.
        /// </summary>
        /// <returns>Login View.</returns>
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
    }
}