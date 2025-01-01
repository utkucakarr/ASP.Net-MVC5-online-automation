using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTricariOtomasyon.Models.Classes;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();

        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice i)
        {
            var values = c.Invoices.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailInvoice(int id)
        {
            var values = c.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            return View(values);
        }

        public ActionResult BringInvoice(int id)
        {
            var values = c.Invoices.Find(id);
            return View("BringInvoice", values);
        }

        public ActionResult UpdateInvoice(Invoice ic)
        {
            var invo = c.Invoices.Find(ic.InvoiceId);
            invo.InvoiceSerialNumber = ic.InvoiceSerialNumber;
            invo.InvoiceOrderNumer = ic.InvoiceOrderNumer;
            invo.TaxOffice = ic.TaxOffice;
            invo.Date = ic.Date;
            invo.Time = ic.Time;
            invo.Deliverer = ic.Deliverer;
            invo.Recipient = ic.Recipient;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddInvoiceItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem i)
        {
            var values = c.InvoiceItems.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            DynamicInvoice dynamicInvoice = new DynamicInvoice();
            dynamicInvoice.Invoices = c.Invoices.ToList();
            dynamicInvoice.Items = c.InvoiceItems.ToList();
            return View(dynamicInvoice);
        }

        public ActionResult SaveDynamicInvoice(string InvoiceSerialNumber, string InvoiceOrderNumer, DateTime Date, string TaxOffice, string Time, string Deliverer, string Recipient, string Total, InvoiceItem[] items)
        {
            Invoice i = new Invoice();
            i.InvoiceSerialNumber = InvoiceSerialNumber;
            i.InvoiceOrderNumer = InvoiceOrderNumer;
            i.Date = Date;
            i.TaxOffice = TaxOffice;
            i.Time = Time;
            i.Deliverer = Deliverer;
            i.Recipient = Recipient;
            i.Total =decimal.Parse(Total);
            c.Invoices.Add(i);
            foreach (var x in items) 
            {
                InvoiceItem invoiceItem = new InvoiceItem();
                invoiceItem.Statement = x.Statement;
                invoiceItem.UnitPrice = x.UnitPrice;
                invoiceItem.InvoiceId = x.InvoiceId;
                invoiceItem.Quantity = x.Quantity;
                invoiceItem.TotalPrice = x.TotalPrice;
                c.InvoiceItems.Add(invoiceItem);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}