using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Cari
        Context c = new Context();

        public ActionResult Index()
        {
            var values = c.Currents.Where(x => x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCurrent(Current p)
        {
            if (ModelState.IsValid)
            {
                p.Status = true;
                var cur = c.Currents.Add(p);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddCurrent");
        }

        public ActionResult DeleteCurrent(int id)
        {
            var cri = c.Currents.Find(id);
            cri.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCurrent(int id)
        {
            var c1 = c.Currents.Find(id);
            c.SaveChanges();
            return View("BringCurrent", c1);
        }

        public ActionResult UpdateCurrent(Current ca)
        {
            if (ModelState.IsValid)
            {
                var cr = c.Currents.Find(ca.CurrentId);
                cr.CurrentName = ca.CurrentName;
                cr.CurrentSurname = ca.CurrentSurname;
                cr.CurrentCity = ca.CurrentCity;
                cr.CurrentEmail = ca.CurrentEmail;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("BringCurrent");
            }
        }

        public ActionResult CustomerSales(int id)
        {
            var values = c.SalesMotions.Where(x => x.CurrentId == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(values);
        }
    }
}