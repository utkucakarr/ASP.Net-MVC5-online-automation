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

        public ActionResult GraphDynamic()
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
            graph.Add(new Graph()
            {
                productName = "Bilgisayar",
                stock = 120
            });
            graph.Add(new Graph()
            {
                productName = "Beyaz Eşya",
                stock = 150
            });
            graph.Add(new Graph()
            {
                productName = "Mobilya",
                stock = 70
            });
            graph.Add(new Graph()
            {
                productName = "Küçük Ev Aletleri",
                stock = 180
            });
            graph.Add(new Graph()
            {
                productName = "Mobil Cihazlar",
                stock = 90
            });
            return graph;
        }

    }
}