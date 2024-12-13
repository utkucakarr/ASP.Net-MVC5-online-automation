using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context c = new Context();
        // GET: CurrentPanel
        [Authorize]
        public ActionResult Index()
        {
            var Email = (string)Session["CurrentEmail"]; // Cari mailden gelen değerleri session'da tutuyoruz.
            var emailQuery = c.Currents.FirstOrDefault(x => x.CurrentEmail == Email);
            ViewBag.email = Email;
            return View(emailQuery);
        }
        public ActionResult Orders()
        {
            var Email = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x => x.CurrentEmail == Email.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var salesMotion = c.SalesMotions.Where(x => x.CurrentId == id).ToList();
            return View(salesMotion);
        }
    }
}