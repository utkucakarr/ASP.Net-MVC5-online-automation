using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class DynamicInvoice
    {
        public IEnumerable<Invoice> Invoices { get; set;}
        public IEnumerable<InvoiceItem> Items { get; set;}
    }
}