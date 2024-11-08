using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class InvoiceItemsController : Controller
    {
        // GET: InvoiceItems Satış Kalemler
        Context c = new Context();

        public ActionResult Index()
        {
            var values = c.InvoiceItems.ToList();
            return View();
        }
    }
}