using MvcOnlineTricariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();

        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges(); // Değerleri ekledikten sonra veri tabanına kaydet.
            return RedirectToAction("Index"); // bu olaydan sonra beni bir aksiyona yönlendir yani index'e yönlendiriyor.
        }

        public ActionResult DeleteCategory(int id)
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCategory(int id)
        {
            var category = c.Categories.Find(id);
            return View("BringCategory", category);
        }
        
        public ActionResult UpdateCategory(Category k)
        {
            var ktgr = c.Categories.Find(k.CategoryId);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}