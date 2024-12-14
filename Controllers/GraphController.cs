using MvcOnlineTricariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class GraphController : Controller
    {
        Context c = new Context();
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Graph> ProductList()
        {
            List<Graph> graph = new List<Graph>();
            using (var context = new Context())
            {
                graph = c.Products.Select(x => new Graph
                {
                    productName = x.ProductName,
                    stock = x.Stock
                }).ToList();
            }
            return graph;
        }
        public ActionResult LineGraph()
        {
            return View();
        }
        public ActionResult ColumnGraph()
        {
            return View();
        }

    }
}