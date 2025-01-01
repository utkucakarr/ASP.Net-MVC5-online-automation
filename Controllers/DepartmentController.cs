using MvcOnlineTricariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        Context c = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var values = c.Departments.Where(x => x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = c.Departments.FirstOrDefault(x => x.DepartmentName == d.DepartmentName);
                if (existingCategory != null)
                {
                    // Aynı isimde kategori varsa hata mesajı ekle
                    ModelState.AddModelError("", "Bu isimde bir departman zaten mevcut.");
                    return View("AddDepartment", d); // Formu tekrar göster
                }
                d.Status = true;
                c.Departments.Add(d);
                c.SaveChanges(); // Değerleri ekledikten sonra veri tabanına kaydet.
                return RedirectToAction("Index"); // bu olaydan sonra beni bir aksiyona yönlendir yani indexe yönlendiriyor.
            }
            else
            {
                // Eğer validasyon hatası varsa, aynı sayfayı tekrar döndür
                return View("AddDepartment");  // Hatalar burada görünecek
            }
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dpt = c.Departments.Find(id);
            dpt.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringDepartment(int id)
        {
            var department = c.Departments.Find(id);
            c.SaveChanges();
            return View("BringDepartment", department);
        }

        public ActionResult UpdateDepartment(Department de)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = c.Departments.FirstOrDefault(x => x.DepartmentName == de.DepartmentName);
                if (existingCategory != null)
                {
                    // Aynı isimde kategori varsa hata mesajı ekle
                    ModelState.AddModelError("", "Bu isimde bir departman zaten mevcut.");
                    return View("AddDepartment", de); // Formu tekrar göster
                }
                var dprtm = c.Departments.Find(de.DepartmentId);
                dprtm.DepartmentName = de.DepartmentName;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("BringDepartment");
            }
        }

        public ActionResult DetailDepartment(int id)
        {
            var values = c.Employes.Where(x => x.DepartmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }

        public ActionResult DepartmentEmployeSales(int id)
        {
            var values = c.SalesMotions.Where(x => x.EmployeId == id).ToList();
            var per = c.Employes.Where(x => x.EmployeId == id).Select(y => y.EmployeName + " " + y.EmployeSurname).FirstOrDefault();
            ViewBag.dpers = per;
            return View(values);
        }
    }
}