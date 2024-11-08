using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class PDetail
    {
        [Key]
        public int PDetailId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string PProductInfo { get; set; }
    }
}