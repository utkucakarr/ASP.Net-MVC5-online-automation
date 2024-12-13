using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context c = new Context();
        // GET: Cargo
        public ActionResult Index(string Search)
        {
            var cargo = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(Search))
            {
                cargo = cargo.Where(y => y.TrackingCode.Contains(Search));
            }
            return View(cargo.ToList());
        }

        [HttpGet]
        public ActionResult AddCargo()
        {
            Random rnd = new Random();
            string[] Character = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, Character.Length);
            k2 = rnd.Next(0, Character.Length);
            k3 = rnd.Next(0, Character.Length);
            int number1, number2, number3;
            number1 = rnd.Next(100, 1000);
            number2 = rnd.Next(10, 99);
            number3 = rnd.Next(10, 99);
            string code = number1 + Character[k1] + number2 + Character[k2] + number3 + Character[k3];
            ViewBag.trackingCode = code;
            return View();
        }

        [HttpPost]
        public ActionResult AddCargo(CargoDetail cd)
        {
            c.CargoDetails.Add(cd);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CargoTracking(string id)
        {
            var trackingQuery = c.CargoTracings.Where(x => x.TrackingCode == id).ToList();
            return View(trackingQuery);
        }
    }
}