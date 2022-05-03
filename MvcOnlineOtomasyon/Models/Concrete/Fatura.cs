using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
        [Column(TypeName="Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaDate { get; set; }
        public string FaturaHour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Delivery { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Submitter { get; set; }

        public decimal SumPrice { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}