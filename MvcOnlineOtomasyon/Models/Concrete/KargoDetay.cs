using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}