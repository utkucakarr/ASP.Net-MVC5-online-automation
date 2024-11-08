using MvcOnlineTricariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Products.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values1 = (from x in c.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName, // Kullanıcı tarafından görülecek alan
                                                Value = x.CategoryId.ToString() // Geliştirici tarafından görülecek alan
                                            }).ToList();
            ViewBag.vls1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            p.Status = true;
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var prd = c.Products.Find(id);
            prd.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringProduct(int id)
        {
            var productvalues = c.Products.Find(id);
            List<SelectListItem> values1 = (from x in c.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName, // Kullanıcı tarafından görülecek alan
                                                Value = x.CategoryId.ToString() // Geliştirici tarafından görülecek alan
                                            }).ToList();
            ViewBag.vls1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View("BringProduct", productvalues);
        }
        public ActionResult UpdateProduct(Product u)
        {
            var prd = c.Products.Find(u.ProductId);
            prd.ProductName = u.ProductName;
            prd.Brand = u.Brand;
            prd.Stock = u.Stock;
            prd.PurchasePrice = u.PurchasePrice;
            prd.SalesPrice = u.SalesPrice;
            prd.CategoryId = u.CategoryId;
            prd.Status = u.Status;
            prd.ProductImage = u.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}