using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context c = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            if(!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(x => x.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }
        public ActionResult Add()
        {
            Random rd = new Random();
            string[] karakter = { "A", "B", "C","D"};

            int k1, k2, k3;
            k1 = rd.Next(0, 4);
            k2 = rd.Next(0, 4);
            k3 = rd.Next(0, 4);

            int s1, s2, s3;
            s1 = rd.Next(100, 1000);
            s2 = rd.Next(10, 100);
            s3 = rd.Next(10, 100);

            string kod = s1 + karakter[k1] + s2 + karakter[k2] + s3 + karakter[k3];

            ViewBag.takipkod = kod;


            return View();
        }
        [HttpPost]
        public ActionResult Add(KargoDetay p)
        {
            c.KargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(int id)
        {
            var deger = c.KargoDetays.Find(id);
            var kargo = c.KargoTakips.Where(x => x.TakipKodu == deger.TakipKodu).ToList();
            return View(kargo);
        }
    }
}