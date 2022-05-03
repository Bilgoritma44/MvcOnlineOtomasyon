using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context c = new Context();
        // GET: CustomerPanel
        public ActionResult Index()
        {
            var mail = User.Identity.Name;
            var deger = c.Customers.Where(x => x.CustomerMail == mail).ToList();
            var customerid = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerId).FirstOrDefault();
            var sales = c.SalesMoves.Where(x => x.CustomerId == customerid).Count();
            ViewBag.s1 = sales;
            var sumprice = c.SalesMoves.Where(x => x.CustomerId == customerid).Sum(y => y.SumPrice);
            ViewBag.s2 = sumprice;
            var sumadet = c.SalesMoves.Where(x => x.CustomerId == customerid).Sum(y => y.Quantity);
            ViewBag.s3 = sumadet;
            return View(deger);
        }
        public ActionResult Profilee(int id)
        {
            id=1;
            var deger = c.Customers.Find(id);
            return View(deger);
        }
        public ActionResult Siparis()
        {
            var mail = User.Identity.Name;
            var id = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerId).FirstOrDefault();
            var deger = c.SalesMoves.Where(x => x.CustomerId == id).ToList();
            return View(deger);
        }
        public ActionResult MessageList()
        {
            var mail = User.Identity.Name;
            var mesaj = c.Messages.Where(x => x.Receiver == mail).ToList();
            var mesaj2 = c.Messages.Where(x => x.Receiver == mail).Count();
            var mesaj3 = c.Messages.Where(x => x.Sender == mail).Count();
            

            ViewBag.v1 = mesaj2;
            ViewBag.v2 = mesaj3;

            return View(mesaj);
        }
        public ActionResult SenderMessage()
        {
            var mail = User.Identity.Name;

            var mesaj = c.Messages.Where(x => x.Sender == mail).ToList();
            return View(mesaj);
        }
        public ActionResult MessageDetail(int id)
        {
            var detay = c.Messages.Where(x=>x.MessageId==id).ToList();
            return View(detay);
        }
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            var mail = User.Identity.Name;
            p.Sender = mail;
            p.Tarih = DateTime.Now;
            c.Messages.Add(p);
            c.SaveChanges();
            return RedirectToAction("MessageList","CustomerPanel");
        }
        public ActionResult KargoGetir(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            kargo = kargo.Where(x => x.TakipKodu.Contains(p));
            return View(kargo.ToList());
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult CustomerMessage()
        {
            var mail = User.Identity.Name;
            var deger = c.Messages.Where(x => x.Receiver == mail).ToList();
            return PartialView(deger);
        }
        public PartialViewResult CustomerProfile()
        {
            var mail = User.Identity.Name;
            var id = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerId).FirstOrDefault();
            var deger = c.Customers.Find(id);
            return PartialView("CustomerProfile", deger);
        }
        [HttpPost]
        public ActionResult CustomerProfile(Customer p)
        {
            var customer = c.Customers.Find(p.CustomerId);
            customer.CustomerName = p.CustomerName;
            customer.CustomerLastname = p.CustomerLastname;
            customer.CustomerCity = p.CustomerCity;
            customer.CustomerMail = p.CustomerMail;
            customer.CustomerPassword = p.CustomerPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult AdminAnnounce()
        {
            var deger = c.Messages.Where(x => x.Sender == "admin@gmail.com").ToList();
            return PartialView(deger);
        }
    }
}