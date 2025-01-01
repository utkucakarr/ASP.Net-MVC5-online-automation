using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context c = new Context();

        public ActionResult Index()
        {
            var values = c.Products.Where(x => x.Status == true).ToList();
            return View(values);
        }
    }
}