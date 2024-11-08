using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        [Display(Name = "Admin Id")]
        public int AdminId { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }
        [Display(Name = "Yetki")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authorization { get; set; }
    }
}