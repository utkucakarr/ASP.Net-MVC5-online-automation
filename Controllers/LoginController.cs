using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialRegister()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialRegister(Current current)
        {
            c.Currents.Add(current);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin(Current current)
        {
            var query = c.Currents.FirstOrDefault(x => x.CurrentEmail == current.CurrentEmail && x.Password == current.Password);
            if(query != null)
            {
                FormsAuthentication.SetAuthCookie(query.CurrentEmail, false);
                Session["CurrentEmail"] = query.CurrentEmail.ToString(); // query içindeki maili sessiona atadık.
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var adminUserName = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(adminUserName != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserName.UserName, false);
                Session["UserName"] = adminUserName.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}