using ProjectStore.DAL;
using ProjectStore.Models.ViewsModels.Collection;
using ProjectStore.Models.ViewsModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace ProjectStore.Controllers
{
    public class CollectionController : Controller
    {
        CartVM shoppingCart = new CartVM();

        [AllowAnonymous]
        public ActionResult Collection()
        {
            ViewBag.Message = "Collection list.";
            CollectionTableVM collection = new CollectionTableVM();

            return View("Collection", collection);
        }
        [Authorize]
        public ActionResult Details1(int id)
        {
            ViewBag.Message = "Details about the art.";
            var db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            CollectionDetailsVM collectionDetailsVM = new CollectionDetailsVM(art);
            return View("Details1", collectionDetailsVM);
        }
        [Authorize]
        public ActionResult Edit1(int id)
        {
            UserDBEntities1 db = new UserDBEntities1();
            CollectionTable art = db.CollectionTables.Where(u => u.Id == id).Single();
            CollectionEditVM collectionDetailsVM = new CollectionEditVM(art);
            return View("Edit1", collectionDetailsVM);
        }
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
        [AllowAnonymous]
        public ActionResult Cart()
        {
            ViewBag.Message = "Here's what you've got in your shopping cart.";
            shoppingCart = (CartVM)Session["shoppingCart"];
            if (Session["shoppingCart"] == null)
                Session["shoppingCart"] = new CartVM();
            return View("Cart", (CartVM)Session["shoppingCart"]);
        }
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Message = "Adding new book/movie to collection.";
            CreateVM ct = new CreateVM();
            return View(ct);
        }
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