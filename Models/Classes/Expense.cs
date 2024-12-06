using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Expense // Gider
    {
        [Key]
        [Display(Name = "Gider Id")]
        public int ExpenseId { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Statement { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }

        [Display(Name = "Tutar")]
        public decimal TotalPrice { get; set; }
    }
}