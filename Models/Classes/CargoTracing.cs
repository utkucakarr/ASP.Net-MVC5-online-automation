using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class CargoTracing
    {
        [Key]
        public int CargoTracingId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [DisplayName("Takip Kodu")]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [DisplayName("Açıklama")]
        public string Statement { get; set; }
        [DisplayName("Tarih Zaman")]
        public DateTime DateTime { get; set; }
    }
}