using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    // Authorize burası hariç her yerde çalışıyor bu komut onun için.
    [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
                current.Status = true;
                c.Currents.Add(current);
                c.SaveChanges();
                return PartialView();
            }
            else
            {
                return PartialView("Index");
            }
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CurrentLogin(string CurrentEmail, string Password)
        {
            var query = c.Currents.FirstOrDefault(x => x.CurrentEmail == CurrentEmail && x.Password == Password && x.Status == true);

            if (query != null)
            {
                // Başarılı giriş işlemleri
                FormsAuthentication.SetAuthCookie(query.CurrentEmail, false); // Oturum açmak için kullanılır. SetAuthCookie kimlik doğrulama yapar. Giriş yapan kullanıcının e posta adresini al. False tarayıcı kapandığında oturumu sonlandır.
                Session["CurrentEmail"] = query.CurrentEmail.ToString(); // kullanıcı oturum bilgisini sesionda tutuyoruz çünkü bu oturum bilgisine diğer sayfalardada ulaşmak için.
                return Json(new { success = true, redirectUrl = "/CurrentPanel/Index/" });
            }
            else
            {
                // Hatalı giriş işlemleri
                return Json(new { success = false, redirectUrl = "/Login/Index/" });
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AdminLogin(string UserName, string Password)
        {
            var query = c.Admins.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);

            if (query != null)
            {
                // Başarılı giriş işlemleri
                FormsAuthentication.SetAuthCookie(query.UserName, false);
                Session["UserName"] = query.UserName.ToString();
                TempData["userName"] = query.UserName;
                return Json(new { success = true, redirectUrl = "/Category/Index" });
            }
            else
            {
                // Hatalı giriş işlemleri
                return Json(new { success = false, redirectUrl = "/Login/Index" });
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // istekleri terket
            return RedirectToAction("Index", "Login");
        }
    }
}