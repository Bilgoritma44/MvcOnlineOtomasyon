using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string PersonelName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string PersonelLastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string PersonelPhoto { get; set; }

        public bool  PersonelStatus { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}