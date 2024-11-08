using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMotions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = value1;
            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();
            ViewBag.dgr2 = values2;
            List<SelectListItem> value3 = (from x in c.Employes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeName + " " + x.EmployeSurname,
                                               Value = x.EmployeId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult AddSales(SalesMotion sm)
        {
            sm.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMotions.Add(sm);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringSales(int id)
        {
            var bs = c.SalesMotions.Find(id);
            List<SelectListItem> values1 = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductId.ToString()
                                            }).ToList();
            ViewBag.dgr1 = values1;
            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();
            ViewBag.dgr2 = values2;
            List<SelectListItem> values3 = (from x in c.Employes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeName + " " + x.EmployeSurname,
                                                Value = x.EmployeId.ToString()
                                            }).ToList();
            ViewBag.dgr3 = values3;
            return View("BringSales", bs);
        }
        public ActionResult UpdateSales(SalesMotion sm)
        {
            var nsm = c.SalesMotions.Find(sm.SalesId);
            nsm.ProductId = sm.ProductId;
            nsm.CurrentId = sm.CurrentId;
            nsm.EmployeId = sm.EmployeId;
            nsm.Quantity = sm.Quantity;
            nsm.Price = sm.Price;
            nsm.TotalPrice = sm.TotalPrice;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailSales(int id)
        {
            var values = c.SalesMotions.Where(x => x.SalesId == id).ToList();
            return View(values);
        }
    }
}