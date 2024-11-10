using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();

        public ActionResult Index()
        {
            Class1 cs = new Class1();
            // var values = c.Products.Where(x => x.ProductId == 1).ToList();
            cs.Value1 = c.Products.Where(x => x.ProductId == 1).ToList();
            cs.Value2 = c.PDetail.Where(y => y.PDetailId == 1).ToList();
            return View(cs);
        }
    }
}