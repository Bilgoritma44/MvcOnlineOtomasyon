using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Concrete
{
    public class GetComment
    {
        public IEnumerable<Product> Deger1 { get; set; }
        public IEnumerable<Comment> Deger2 { get; set; }
    }
}