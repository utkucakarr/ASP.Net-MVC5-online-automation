using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();

        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.d1 = values1;
            var values2 = c.Products.Count().ToString();
            ViewBag.d2 = values2;
            var values3 = c.Employes.Count().ToString();
            ViewBag.d3 = values3;
            var values4 = c.Categories.Count().ToString();
            ViewBag.d4 = values4;
            var values5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = values5;
            var values6 = (from x in c.Products select x.Brand).Distinct().Count().ToString(); // distinct benzersiz değerleri getirmek için kullanılır
            ViewBag.d6 = values6;
            var values7 = c.Products.Count(x => x.Stock <= 20).ToString(); // Kritik seviye stok sayısı 20'nin altında olanların sayısı
            ViewBag.d7 = values7;
            var values8 = (from x in c.Products orderby x.SalesPrice descending select x.ProductName).FirstOrDefault(); // descending tersten sıralamak için kullanılır.
            ViewBag.d8 = values8;
            var values9 = (from x in c.Products orderby x.SalesPrice ascending select x.ProductName).FirstOrDefault(); // ascending A'dan Z'ye sıralamak için kullanılır.
            ViewBag.d9 = values9;
            var values10 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = values10;
            var values11 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d11 = values11;
            var values12 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d12 = values12;
            var values13 = c.Products.Where(u => u.ProductId == (c.SalesMotions.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault(); // Buradaki key seçtiğimiz değeri almak için kullanılıyor.
            ViewBag.d13 = values13;
            var values14 = c.SalesMotions.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = values14;
            DateTime today = DateTime.Today;
            var values15 = c.SalesMotions.Count(x => x.Date == today).ToString();
            ViewBag.d15 = values15;
            var values16 = c.SalesMotions.Where(x => x.Date == today).Sum(y => (decimal?)y.TotalPrice).ToString(); //defaultifempty Boş ise 0 değerini atıyor
            ViewBag.d16 = values16;
            return View();
        }
        public ActionResult SimpleTables()
        {
            var query = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            NumberOfCities = g.Count(),
                        };
            return View(query);
        }
        public PartialViewResult PartialSimpleTables() // Parçalı view
        {
            var PstQuery = from x in c.Employes
                           group x by x.Department.DepartmentName into g
                           select new GroupClass2
                           {
                               Department = g.Key,
                               Number = g.Count(),
                           };
            return PartialView(PstQuery.ToList());
        }
        public PartialViewResult PartialCurrent()
        {
            var crtQuery = c.Currents.ToList();
            return PartialView(crtQuery);
        }
        public PartialViewResult PartialProduct()
        {
            var productQuery = c.Products.ToList();
            return PartialView(productQuery);
        }
        public PartialViewResult PartialCategory()
        {
            var categoryQuery = c.Categories.ToList();
            return PartialView(categoryQuery);
        }
        public PartialViewResult PartialProductBrand()
        {
            return PartialView();
        }
        public PartialViewResult PartialForBrand()
        {
            var brandQuery = from x in c.Products
                             group x by x.Brand into g
                             select new GroupClassesForBrand
                             {
                                 Brand = g.Key,
                                 Number = g.Count()
                             };
            return PartialView(brandQuery.ToList());
        }
    }
}