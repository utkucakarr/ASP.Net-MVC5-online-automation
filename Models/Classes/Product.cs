using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        [Display(Name = "Ürün Id")]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")] // Data Annotation
        [StringLength(30)]
        public string ProductName { get; set; }
        [Display(Name = "Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Display(Name = "Stok")]
        public short Stock { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SalesPrice { get; set; }
        [Display(Name = "Durum")]
        public bool Status { get; set; }
        [Display(Name = "Ürün Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } // Kategori sınıfındaki değerlere ulaşmak için virtual kullanıyoruz.
        public ICollection<SalesMotion> SalesMotions { get; set; }
    }
}