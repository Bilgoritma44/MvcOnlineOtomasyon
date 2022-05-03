using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class SalesMoveController : Controller
    {
        Context c = new Context();
        // GET: SalesMove
        public ActionResult Index()
        {
            var deger = c.SalesMoves.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            List<SelectListItem> product = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text=x.ProductName,
                                                Value=x.ProductId.ToString()
                                            }).ToList();

            ViewBag.v1 = product;

            List<SelectListItem> personel = (from x in c.Personels.Where(x => x.PersonelStatus == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName+" "+x.PersonelLastName,
                                                Value = x.PersonelId.ToString()
                                            }).ToList();

            ViewBag.v2 = personel;
            
            List<SelectListItem> customer = (from x in c.Customers.Where(x=>x.CustomerStatus==true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CustomerName+" "+x.CustomerLastname,
                                                Value = x.CustomerId.ToString()
                                            }).ToList();

            ViewBag.v3 = customer;


            return View();
        }
        [HttpPost]
        public ActionResult Add(SalesMove p)
        {
            c.SalesMoves.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> product = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductId.ToString()
                                            }).ToList();

            ViewBag.v1 = product;

            List<SelectListItem> personel = (from x in c.Personels.Where(x => x.PersonelStatus == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelName + " " + x.PersonelLastName,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();

            ViewBag.v2 = personel;

            List<SelectListItem> customer = (from x in c.Customers.Where(x => x.CustomerStatus == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CustomerName + " " + x.CustomerLastname,
                                                 Value = x.CustomerId.ToString()
                                             }).ToList();

            ViewBag.v3 = customer;
            
            var deger = c.SalesMoves.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(SalesMove p)
        {
            SalesMove salesMove = c.SalesMoves.Where(x => x.SalesMoveId == p.SalesMoveId).SingleOrDefault();
            salesMove.ProductId = p.ProductId;
            salesMove.PersonelId = p.PersonelId;
            salesMove.CustomerId = p.CustomerId;
            salesMove.Price = p.Price;
            salesMove.Quantity = p.Quantity;
            salesMove.SumPrice = p.SumPrice;
            salesMove.Date = p.Date;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger = c.SalesMoves.Where(x => x.SalesMoveId == id).ToList();
            return View(deger);
        }
    }
}