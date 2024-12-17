using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context c = new Context();
        // GET: CurrentPanel

        [Authorize]
        public ActionResult Index()
        {
            var Email = (string)Session["CurrentEmail"]; // Cari mailden gelen değerleri session'da tutuyoruz.
            var emailQuery = c.Messages.Where(x => x.Receiver == Email).ToList();
            ViewBag.email = Email;
            var mailId = c.Currents.Where(x => x.CurrentEmail == Email).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.mailid = mailId;
            var totalSales = c.SalesMotions.Where(x => x.CurrentId == mailId).Count();
            ViewBag.totalSales = totalSales;
            var totalPrice = c.SalesMotions.Where(x => x.CurrentId == mailId).Select(y => y.TotalPrice).DefaultIfEmpty(0).Sum();
            ViewBag.totalPrice = totalPrice;
            var salesProductCount = c.SalesMotions.Where(x => x.CurrentId == mailId).Select(y => y.Quantity).DefaultIfEmpty(0).Sum();
            ViewBag.salesProductCount = salesProductCount;
            var nameSurname = c.Currents.Where(x => x.CurrentId == mailId).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;
            return View(emailQuery);
        }

        [Authorize]
        public ActionResult Orders()
        {
            var Email = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x => x.CurrentEmail == Email.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var salesMotion = c.SalesMotions.Where(x => x.CurrentId == id).ToList();
            return View(salesMotion);
        }

        [Authorize]
        public ActionResult IncomingMessages()
        {
            var Email = (string)Session["CurrentEmail"];
            var messages = c.Messages.Where(x => x.Receiver == Email).OrderByDescending(y => y.MessageId).ToList();
            var incomingMessages = c.Messages.Count(x => x.Receiver == Email).ToString(); // Gelen mesajların sayısını tutma
            var outgoingMessages = c.Messages.Count(x => x.Sender == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.incomingMes = incomingMessages;
            ViewBag.outgoingMes = outgoingMessages;
            return View(messages);
        }

        [Authorize]
        public ActionResult OutGoingMessages()
        {
            var Email = (string)Session["CurrentEmail"];
            var messages = c.Messages.Where(x => x.Sender == Email).OrderByDescending(y => y.MessageId).ToList();
            var incomingMessages = c.Messages.Count(x => x.Receiver == Email).ToString(); // Gelen mesajların sayısını tutma
            var outgoingMessages = c.Messages.Count(x => x.Sender == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.incomingMes = incomingMessages;
            ViewBag.outgoingMes = outgoingMessages;
            return View(messages);
        }

        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var detailMessage = c.Messages.Where(x => x.MessageId == id).ToList();
            var Email = (string)Session["CurrentEmail"];
            var incomingMessages = c.Messages.Count(x => x.Receiver == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.incomingMes = incomingMessages;
            var outgoingMessages = c.Messages.Count(x => x.Sender == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.outgoingMes = outgoingMessages;
            return View(detailMessage);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            var Email = (string)Session["CurrentEmail"];
            var incomingMessages = c.Messages.Count(x => x.Receiver == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.incomingMes = incomingMessages;
            var outgoingMessages = c.Messages.Count(x => x.Sender == Email).ToString(); // Gelen mesajların sayısını tutma
            ViewBag.outgoingMes = outgoingMessages;
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var Email = (string)Session["CurrentEmail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = Email;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult CargoTracking(string Search)
        {
            var cargo = from x in c.CargoDetails select x;
            cargo = cargo.Where(y => y.TrackingCode.Contains(Search));
            return View(cargo.ToList());
        }

        public ActionResult CurrentCargoTracking(string id)
        {
            var cargos = c.CargoTracings.Where(x => x.TrackingCode == id).ToList();
            return View(cargos);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // istekleri terket
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult ProfilePartialPassword()
        {
            var Email = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x => x.CurrentEmail == Email).Select(y => y.CurrentId).FirstOrDefault();
            var findCurrent = c.Currents.Find(id);
            return PartialView("ProfilePartialPassword", findCurrent);
        }

        public PartialViewResult PartialNotice()
        {
            var messagesValues = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(messagesValues);
        }

        public ActionResult CurrentPanelUpdateInfo(Current current)
        {
            var currentInfo = c.Currents.Find(current.CurrentId);
            currentInfo.CurrentName = current.CurrentName;
            currentInfo.CurrentSurname = current.CurrentSurname;
            currentInfo.Password = current.Password;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}