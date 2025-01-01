using MvcOnlineTricariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();

        public ActionResult Index(int page = 1)
        {
            var values = c.Categories.Where(x => x.Status == true).ToList().ToPagedList(page, 4);
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
            
            if (ModelState.IsValid) // formdan gelen veriler doğrulama kurallarına uyuyor mu
            {
                var existingCategory = c.Categories.FirstOrDefault(x => x.CategoryName == k.CategoryName);
                if (existingCategory != null)
                {
                    // Aynı isimde kategori varsa hata mesajı ekle
                    ModelState.AddModelError("", "Bu isimde bir kategori zaten mevcut.");
                    return View("AddCategory", k); // Formu tekrar göster
                }
                k.Status = true;
                c.Categories.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddCategory");
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            var ktg = c.Categories.Find(id);
            ktg.Status = false;
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
            if (ModelState.IsValid)
            {
                var existingCategory = c.Categories.FirstOrDefault(x => x.CategoryName == k.CategoryName);
                if (existingCategory != null)
                {
                    // Aynı isimde kategori varsa hata mesajı ekle
                    ModelState.AddModelError("", "Bu isimde bir kategori zaten mevcut.");
                    return View("AddCategory", k); // Formu tekrar göster
                }
                var ktgr = c.Categories.Find(k.CategoryId);
                ktgr.CategoryName = k.CategoryName;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("BringCategory");
            }
        }

        public ActionResult CategoryandProductDropDownList()
        {
            Dropdownlist dl = new Dropdownlist();
            dl.Categories = new SelectList(c.Categories, "CategoryId", "CategoryName");
            dl.Products = new SelectList(c.Products, "ProductId", "ProductName");
            return View(dl);
        }

        public ActionResult BringProductforDropDownList(int p)
        {
            var productList = (from x in c.Products
                               join y in c.Categories
                               on x.Category.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString()
                               }).ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}