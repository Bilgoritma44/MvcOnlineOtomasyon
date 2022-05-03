using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var deger = c.Faturas.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Fatura p)
        {
            c.Faturas.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Faturas.Find(id);
            return View(deger); 
        }
        [HttpPost]
        public ActionResult Update(Fatura p)
        {
            Fatura fatura = c.Faturas.Where(x => x.FaturaId == p.FaturaId).SingleOrDefault();
            fatura.FaturaSeriNo = p.FaturaSeriNo;
            fatura.FaturaSıraNo = p.FaturaSıraNo;
            fatura.VergiDairesi = p.VergiDairesi;
            fatura.FaturaDate = p.FaturaDate;
            fatura.FaturaHour = p.FaturaHour;
            fatura.SumPrice = p.SumPrice;
            fatura.Delivery = p.Delivery;
            fatura.Submitter = p.Submitter;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            var deger2 = c.Faturas.Find(id);
            ViewBag.v1 = deger2.Delivery;
            return View(deger);
        }
        public ActionResult KalemAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KalemAdd(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.Deger1 = c.Faturas.ToList();
            cs.Deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSıraNo,DateTime FaturaDate,string FaturaHour,string VergiDairesi,string Delivery,string Submitter,string SumPrice,FaturaKalem[] kalems )
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.FaturaDate = FaturaDate;
            f.VergiDairesi = VergiDairesi;
            f.FaturaHour = FaturaHour;
            f.Delivery = Delivery;
            f.Submitter = Submitter;
            f.SumPrice = decimal.Parse(SumPrice);
            c.Faturas.Add(f);
            foreach (var x in kalems)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.FaturaId = x.FaturaKalemId;
                fk.Description = x.Description;
                fk.Quantity = x.Quantity;
                fk.UnitQuantity = x.UnitQuantity;
                fk.Amount = x.Amount;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}