using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var deger = from x in c.Products select x;
            if(!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(x => x.ProductName.Contains(p));
            }
            return View(deger.Include(x=>x.Category).ToList());
        }
        public ActionResult Add()
        {
            List<SelectListItem> categori=(from x in c.Categories.ToList()
                                           
                                         select new SelectListItem
                                           {
                                             Text=x.CategoryName,
                                             Value=x.CategoryId.ToString()

                                           }).ToList();
            ViewBag.v1 = categori;

            return View();
        }
        [HttpPost]
        public ActionResult Add(Product p)
        {
            p.Status = true;
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Products.Find(id);
            c.Products.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> categori = (from x in c.Categories.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()

                                             }).ToList();
            ViewBag.v1 = categori;

            var deger = c.Products.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            Product product = c.Products.Where(x => x.ProductId == p.ProductId).SingleOrDefault();
            product.ProductName = p.ProductName;
            product.ProductPhoto = p.ProductPhoto;
            product.CategoryId = p.CategoryId;
            product.PurchasePrice = p.PurchasePrice;
            product.SalesPrice = p.SalesPrice;
            product.Stock = p.Stock;
            product.Status = p.Status;
            product.Marka = p.Marka;

            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ProductListDocument()
        {
            var deger = c.Products.Include(x=>x.Category).ToList();
            return View(deger);
        }
        public ActionResult ProductSales(int id)
        {
            var deger = c.Products.Find(id);
            ViewBag.d1 = deger.ProductId;
            ViewBag.d2 = deger.SalesPrice;
            //List<SelectListItem> product = (from x in c.Products.ToList()
            //                                select new SelectListItem
            //                                {
            //                                    Text = x.ProductName,
            //                                    Value = x.ProductId.ToString()
            //                                }).ToList();

            //ViewBag.v1 = product;

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

            return View();
        }
        [HttpPost]
        public ActionResult ProductSales(SalesMove p)
        {
            p.Date = DateTime.Now;
            c.SalesMoves.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","SalesMove");
        }
    }
}