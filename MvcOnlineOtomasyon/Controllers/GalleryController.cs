using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context c = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var deger = c.Products.ToList();
            return View(deger);
        }
    }
}