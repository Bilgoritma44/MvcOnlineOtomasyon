using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitQuantity { get; set; }
        public decimal Amount { get; set; }
        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}