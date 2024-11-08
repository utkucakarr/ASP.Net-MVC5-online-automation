using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        [Display(Name = "Fatura Id")]
        public int InvoiceId { get; set; }
        [Display(Name = "Fatura Seri Numarası")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }
        [Display(Name = "Fatura Sıra Numarası")]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceOrderNumer { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }
        [Display(Name = "Saat")]
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Time { get; set; }
        [Display(Name = "Teslim Eden")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }
        [Display(Name = "Teslim Alan")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }
        [Display(Name = "Toplam")]
        public decimal Total { get; set; } //Toplam tutar için kullanılacaks
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}