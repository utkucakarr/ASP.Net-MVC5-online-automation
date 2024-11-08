using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class SalesMotion
    {
        [Key]
        [Display(Name = "Satış Id")]
        public int SalesId { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Toplam Tutar")]
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int EmployeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employe Employe { get; set; }
    }
}