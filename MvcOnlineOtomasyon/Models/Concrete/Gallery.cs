using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class Gallery
    {
        [Key]
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}