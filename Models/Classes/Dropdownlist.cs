using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Dropdownlist
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}