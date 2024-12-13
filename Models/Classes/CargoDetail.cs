using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        [DisplayName("Açıklama")]
        public string Statement { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [DisplayName("Takip Kodu")]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [DisplayName("Personel")]
        public string Employe { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [DisplayName("Alıcı")]
        public string Recipient { get; set; }

        [DisplayName("Tarih")]
        public DateTime Date { get; set; }
    }
}