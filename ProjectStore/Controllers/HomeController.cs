using ProjectStore.DAL;
using ProjectStore.Models.ViewsModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace ProjectStore.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Show about view.
        /// </summary>
        /// <returns>About View.</returns>
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Here are short informations about us.";

            return View();
        }

        /// <summary>
        /// Show contact view.
        /// </summary>
        /// <returns>Contact View.</returns>
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Here are all the informations and contact to our stores.";

            return View();
        }

        /// <summary>
        /// Shows customers view.
        /// </summary>
        /// <returns>Customers View.</returns>
        [Authorize]
        public ActionResult Customers()
        {
            ViewBag.Message = "Registered customeres list.";
            CustomersVM customers = new CustomersVM();
            return View("Customers", customers);
        }

        /// <summary>
        /// Show details of user.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Details View.</returns>
        [Authorize]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Details about customer.";
            var db = new UserDBEntities();
            UserTable user = db.UserTables.Where(u => u.UserID == id).Single();
            UserDetailsVM userDetailsVM = new UserDetailsVM(user);
            return View("Details", userDetailsVM);
        }

        /// <summary>
        /// Show details of user.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Action Edit.</returns>
        [Authorize]
        public ActionResult Edit(int id)
        {
            UserDBEntities db = new UserDBEntities();
            UserTable user = db.UserTables.Where(u => u.UserID == id).Single();
            UserEditVM userEditVM = new UserEditVM(user);
            return View("Edit", userEditVM);
        }

        /// <summary>
        /// Edit user.
        /// </summary>
        /// <param name="user">Element from user list of type UserEditVM.</param>
        /// <returns>Customers View.</returns>
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

        /// <summary>
        /// Remove user.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Customers View.</returns>
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