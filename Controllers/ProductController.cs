using MvcOnlineTricariOtomasyon.Models.Classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();

        public ActionResult Index(string Search)
        {
            var product = from x in c.Products select x;
            if (!string.IsNullOrEmpty(Search))
            {
                product = product.Where(y => y.ProductName.Contains(Search));
            }
            return View(product.Where(x => x.Status == true).ToList());
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values1 = (from x in c.Categories
                                            where x.Status == true
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.vls1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            if (Request.Files.Count > 0) // Yüklenen dosya varmı yok mu onu kontrol eder.
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ProductImage = "/Images/" + fileName + extension;
            }
            if (ModelState.IsValid)
            {
                p.Status = true;
                c.Products.Add(p);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddProduct");
            }
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
            List<SelectListItem> values1 = (from x in c.Categories
                                            where x.Status == true
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
            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string extension = Path.GetExtension(Request.Files[0].FileName);
            //    string path = "~/Images/" + fileName + extension;
            //    Request.Files[0].SaveAs(Server.MapPath(path));
            //    u.ProductImage = "/Images/" + fileName + extension;
            //}
            var prd = c.Products.Find(u.ProductId);
            prd.ProductName = u.ProductName;
            prd.Brand = u.Brand;
            prd.Stock = u.Stock;
            prd.PurchasePrice = u.PurchasePrice;
            prd.SalesPrice = u.SalesPrice;
            prd.CategoryId = u.CategoryId;
            //prd.ProductImage = u.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult MakeSales(int id)
        {
            List<SelectListItem> value3 = (from x in c.Employes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeName + " " + x.EmployeSurname,
                                               Value = x.EmployeId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = value3;
            var product = c.Products.Find(id);
            ViewBag.dgr1 = product.ProductId;
            ViewBag.price = product.SalesPrice;
            return View();
        }
        [HttpPost]
        public ActionResult MakeSales(SalesMotion sm)
        {
            sm.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMotions.Add(sm);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}