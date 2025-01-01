using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        [Display(Name = "Kategori Id")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Kategori Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [Display(Name = "Durum")]
        public bool Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}