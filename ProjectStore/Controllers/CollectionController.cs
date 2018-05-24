using ProjectStore.DAL;
using ProjectStore.Models.ViewsModels.Collection;
using ProjectStore.Models.ViewsModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace ProjectStore.Controllers
{
    /// <summary>
    /// Collection controller.
    /// </summary>
    public class CollectionController : Controller
    {
        CartVM shoppingCart = new CartVM();

        /// <summary>
        /// Show collection view.
        /// </summary>
        /// <returns>Collection View.</returns>
        [AllowAnonymous]
        public ActionResult Collection()
        {
            ViewBag.Message = "Collection list.";
            CollectionTableVM collection = new CollectionTableVM();

            return View("Collection", collection);
        }

        /// <summary>
        /// Show details of item from collection.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Detail View for an item.</returns>
        [Authorize]
        public ActionResult Details1(int id)
        {
            ViewBag.Message = "Details about the art.";
            var db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            CollectionDetailsVM collectionDetailsVM = new CollectionDetailsVM(art);
            return View("Details1", collectionDetailsVM);
        }

        /// <summary>
        /// Edit item from collection.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Action Edit.</returns>
        [Authorize]
        public ActionResult Edit1(int id)
        {
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            CollectionEditVM collectionDetailsVM = new CollectionEditVM(art);
            return View("Edit1", collectionDetailsVM);
        }
        
        /// <summary>
        /// Edit item from collection.
        /// </summary>
        /// <param name="art">Element from collection of type CollectionEditVM.</param>
        /// <returns>Collection Action.</returns>
        [HttpPost]
        public ActionResult Edit1(CollectionEditVM art)
        {
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable artToUpdate = db.CollectionTables.Where(u => u.Id == art.Id).Single();
            artToUpdate.Title = art.Title;
            artToUpdate.Author = art.Author;
            artToUpdate.Director = art.Director;
            artToUpdate.DateReleased = art.DateReleased;
            artToUpdate.Price = art.Price;
            artToUpdate.Type = art.Type;
            db.SaveChanges();
            return Collection();
        }

        /// <summary>
        /// Remove item from collection.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Collection Action.</returns>
        [Authorize]
        public ActionResult Remove1(int id)
        {
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            if (art != null)
                db.CollectionTables.Remove(art);
            db.SaveChanges();
            return Collection();
        }

        /// <summary>
        /// Remove item from shopping cart.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Cart Action.</returns>
        [AllowAnonymous]
        public ActionResult Remove2(int id)
        {
            shoppingCart = (CartVM)Session["shoppingCart"];
            if (Session["shoppingCart"] == null)
                Session["shoppingCart"] = new CartVM();
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            if (art != null)
                shoppingCart.Remove(art);
            Session["shoppingCart"] = shoppingCart;
            return Cart();
        }

        /// <summary>
        /// Show shopping cart view.
        /// </summary>
        /// <returns>Shopping cart View.</returns>
        [AllowAnonymous]
        public ActionResult Cart()
        {
            ViewBag.Message = "Here's what you've got in your shopping cart.";
            shoppingCart = (CartVM)Session["shoppingCart"];
            if (Session["shoppingCart"] == null)
                Session["shoppingCart"] = new CartVM();
            return View("Cart", (CartVM)Session["shoppingCart"]);
        }

        /// <summary>
        /// Add item to shopping cart.
        /// </summary>
        /// <param name="id">Id of item from collection.</param>
        /// <returns>Collection View.</returns>
        [AllowAnonymous]
        public ActionResult Add(int id)
        {
            shoppingCart = (CartVM)Session["shoppingCart"];
            if (Session["shoppingCart"] == null)
                Session["shoppingCart"] = new CartVM();
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            if (art != null)
                shoppingCart.Add(art);
            Session["shoppingCart"] = shoppingCart;
            return Collection();
        }

        /// <summary>
        /// Create new item to collection.
        /// </summary>
        /// <returns>Action Create.</returns>
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Message = "Adding new book/movie to collection.";
            CreateVM ct = new CreateVM();
            return View(ct);
        }

        /// <summary>
        /// Create new item to collection.
        /// </summary>
        /// <param name="ct">Element of type CreateVM.</param>
        /// <returns>Create View.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVM ct)
        {
            using (UserDBEntities1 db = new UserDBEntities1())
            {
                if (db.CollectionTables.Any(x => x.Title == ct.collectionTable.Title))
                {
                    ViewBag.DuplicateMessage = "Item already exists.";
                    return View("Create", ct);
                }
                db.CollectionTables.Add(ct.collectionTable);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Creation Successful.";
            return View("Create", new CreateVM());
        }
    }
}