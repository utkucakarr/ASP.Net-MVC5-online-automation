using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context c = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            var currentsCount = c.Currents.Where(x => x.Status == true).Count().ToString();
            ViewBag.currentsC = currentsCount;
            var productsCount = c.Products.Where(x => x.Status == true).Count().ToString();
            ViewBag.productsC = productsCount;
            var categoryCount = c.Categories.Count().ToString();
            ViewBag.categoryC = categoryCount;
            var currentCitiesCount = (from x in c.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.currentsCityC = currentCitiesCount;

            var ToDoList = c.ToDoLists.ToList();
            return View(ToDoList);
        }
        [HttpGet]
        public PartialViewResult AddToDolist()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddToDolist(ToDoList toDoList)
        {
            c.ToDoLists.Add(toDoList);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}