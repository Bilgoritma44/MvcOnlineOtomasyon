using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        public string Description { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Date { get; set; }
    }
}