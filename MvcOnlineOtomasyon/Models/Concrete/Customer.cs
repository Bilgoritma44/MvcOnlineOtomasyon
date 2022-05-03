using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerLastname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CustomerCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; }

        public string CustomerPassword { get; set; }

        public bool CustomerStatus { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}