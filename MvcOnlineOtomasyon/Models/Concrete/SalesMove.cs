using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SumPrice { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public int PersonelId { get; set; }
        public int CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Customer Customer { get; set; }
    }
}