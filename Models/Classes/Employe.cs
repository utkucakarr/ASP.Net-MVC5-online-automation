using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Employe
    {
        [Key]
        [Display(Name = "Personel Id")]
        public int EmployeId { get; set; }
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeName { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeSurname { get; set; }
        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeImage { get; set; }
        public ICollection<SalesMotion> SalesMotions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}