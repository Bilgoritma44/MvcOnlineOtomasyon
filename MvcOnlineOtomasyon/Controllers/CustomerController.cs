using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var deger = c.Customers.Where(x=>x.CustomerStatus==true).ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Customer p)
        {
            p.CustomerStatus = true;
            c.Customers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Customers.Find(id);
            deger.CustomerStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Customers.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Customer p)
        {
            Customer customer = c.Customers.Where(x => x.CustomerId == p.CustomerId).SingleOrDefault();
            customer.CustomerName = p.CustomerName;
            customer.CustomerLastname = p.CustomerLastname;
            customer.CustomerCity = p.CustomerCity;
            customer.CustomerMail = p.CustomerMail;

            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Detail(int id)
        {
            var deger = c.SalesMoves.Where(x => x.CustomerId == id).ToList();
            var deger2 = c.Customers.Find(id);
            ViewBag.v1 = deger2.CustomerName + " " + deger2.CustomerLastname;
            return View(deger);
        }
    }
}