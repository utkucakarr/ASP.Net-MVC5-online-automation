using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class EmployeController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var values = c.Employes.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmploye()
        {
            List<SelectListItem> values1 = (from x in c.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName, // Kullanıcı tarafından görülecek alan
                                                Value = x.DepartmentId.ToString() // Geliştirici tarafından görülecek alan
                                            }).ToList();
            ViewBag.dgr1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View();
        }
        [HttpPost]
        public ActionResult AddEmploye(Employe p) // Personel p bana p isminde bir parametre türet demek
        {
            var per = c.Employes.Add(p); // burada veri tabanına p parametresi içindeki değerleri ekletiyoruz.
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringEmploye(int id)
        {
            var employe = c.Employes.Find(id);
            List<SelectListItem> values1 = (from x in c.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName, // Kullanıcı tarafından görülecek alan
                                                Value = x.DepartmentId.ToString() // Geliştirici tarafından görülecek alan
                                            }).ToList();
            ViewBag.vls1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View("BringEmploye", employe);
        }
        public ActionResult UpdateEmploye(Employe e)
        {
            var emp = c.Employes.Find(e.EmployeId);
            emp.EmployeName = e.EmployeName;
            emp.EmployeSurname = e.EmployeSurname;
            emp.EmployeImage = e.EmployeImage;
            emp.DepartmentId = e.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}