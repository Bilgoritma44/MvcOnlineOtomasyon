using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }
        public DateTime Tarih { get; set; }
    }
}