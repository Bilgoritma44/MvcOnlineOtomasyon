using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context c = new Context();
        GetComment g = new GetComment();
        // GET: ProductDetail
        public ActionResult Index()
        {
            g.Deger1 = c.Products.Where(x => x.ProductId == 1).ToList();
            g.Deger2 = c.Comments.Where(y => y.CommentId == 1).ToList();
            return View(g);
        }
    }
}