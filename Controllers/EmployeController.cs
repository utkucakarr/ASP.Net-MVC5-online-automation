using System;
using System.Collections.Generic;
using System.IO;
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
            List<SelectListItem> values1 = (from x in c.Departments
                                            where x.Status == true
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName, // Kullanıcı tarafından görülecek alan
                                                Value = x.DepartmentId.ToString() // Geliştirici tarafından görülecek alan
                                            }).ToList();
            ViewBag.dgr1 = values1; // buradaki dgr1 ViewBag ile kendimiz tanımlıyoruz.
            return View();
        }

        [HttpPost]
        public ActionResult AddEmploye(Employe p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.EmployeImage = "/Images/" + fileName + extension;
            }
            var per = c.Employes.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringEmploye(int id)
        {
            var employe = c.Employes.Find(id);
            List<SelectListItem> values1 = (from x in c.Departments
                                            where x.Status == true
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
            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string extension = Path.GetExtension(Request.Files[0].FileName);
            //    string path = "~/Images/" + fileName + extension;
            //    Request.Files[0].SaveAs(Server.MapPath(path));
            //    e.EmployeImage = "/Images/" + fileName + extension;
            //}
            if (ModelState.IsValid)
            {
                var emp = c.Employes.Find(e.EmployeId);
                emp.EmployeName = e.EmployeName;
                emp.EmployeSurname = e.EmployeSurname;
                //emp.EmployeImage = e.EmployeImage;
                emp.DepartmentId = e.DepartmentId;
                emp.PhoneNumber = e.PhoneNumber;
                emp.Email = e.Email;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("BringEmploye");
            }
        }
        public ActionResult EmployeeList()
        {
            var employeQuery = c.Employes.ToList();
            return View(employeQuery);
        }
    }
}