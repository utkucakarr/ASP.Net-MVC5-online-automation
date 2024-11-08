using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Department
    {
        [Key]
        [Display(Name = "Departman Id")]
        public int DepartmentId { get; set; }
        [Display(Name = "Departman")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Display(Name = "Durum")]
        public bool Status { get; set; }
        public ICollection<Employe> Employes { get; set; }
    }
}