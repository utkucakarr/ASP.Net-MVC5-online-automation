using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        [Display(Name = "Fatura Kalem Id")]
        public int InvoiveItemId { get; set; }
        [Display(Name = "Açıklama")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Statement { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Tutar")]
        public decimal TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}