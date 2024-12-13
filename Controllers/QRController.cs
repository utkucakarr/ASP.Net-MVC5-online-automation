using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generateCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = generateCode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap photo = qrCode.GetGraphic(10))
                {
                    photo.Save(ms, ImageFormat.Png);
                    ViewBag.qrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
                return View();
        }
    }
}