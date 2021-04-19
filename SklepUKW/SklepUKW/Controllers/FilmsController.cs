using SklepUKW.DAL;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db = new FilmsContext();
        // GET: Films
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToLower() == categoryName.ToLower()).Single();
            var nowosci = db.Films.OrderByDescending(f => f.AddDate).Take(3);
            IndexViewModel ivm = new IndexViewModel();
            ivm.FilmsFromCategory = category.Films.ToList();
            ivm.Top3NewestFilms = nowosci;
            ivm.Category = category;
            return View(ivm);
        }

        public ActionResult Details(int id)
        {
            var film = db.Films.Find(id);
            return View(film);
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }

        [ChildActionOnly]
        public ActionResult FilmsFromCategory(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToLower() == categoryName.ToLower()).Single();
            return PartialView("_FilmsFromCategory", category.Films.ToList());
        }
    }
}