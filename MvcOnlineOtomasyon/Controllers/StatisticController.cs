using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            var d1 = c.Products.Count();
            var d2 = c.Personels.Count();
            var d3 = c.Categories.Count();
            var d4 = c.Customers.Count();
            var d5 = c.Departments.Count();
            var d6 = c.Products.Sum(x => x.Stock);
            var d7 = c.Products.Select(x=>x.Marka).Distinct().Count();
            var d8 = c.Products.Count(x=>x.Stock <=20);
            var d9 = c.Products.OrderByDescending(x => x.SalesPrice).Select(x => x.ProductName).FirstOrDefault();
            var d10 = c.Products.OrderBy(x => x.SalesPrice).Select(x => x.ProductName).FirstOrDefault();
            var d11 = c.Products.OrderByDescending(x => x.SalesPrice).Select(x => x.Marka).FirstOrDefault();
            var d12 = c.Products.Where(x => x.Category.CategoryName == "Bilgisayar").Sum(y => y.Stock);
            var d13 = c.Products.Where(x => x.Category.CategoryName == "Beyaz Eşya").Sum(y => y.Stock);
            var d14 = c.SalesMoves.Sum(x => x.SumPrice);
            DateTime today = DateTime.Today;
            var d15 = c.SalesMoves.Count(x => x.Date == today);
            var d16 = c.SalesMoves.Where(x => x.Date == today).Sum(y => (decimal?)y.SumPrice);

            var d17 = c.Products.Where(a => a.ProductId == c.SalesMoves.GroupBy(b => b.ProductId).OrderByDescending(m => m.Count()).Select(n => n.Key).FirstOrDefault()).Select(k=>k.ProductName).FirstOrDefault();

            ViewBag.v1 = d1;
            ViewBag.v2 = d2;
            ViewBag.v3 = d3;
            ViewBag.v4 = d4;
            ViewBag.v5 = d5;
            ViewBag.v6 = d6;
            ViewBag.v7 = d7;
            ViewBag.v8 = d8;
            ViewBag.v9 = d9;
            ViewBag.v10 = d10;
            ViewBag.v11 = d11;
            ViewBag.v12 = d12;
            ViewBag.v13 = d13;
            ViewBag.v14 = d14;
            ViewBag.v15 = d15;
            //ViewBag.v16 = d16;
            ViewBag.v17 = d17;
            return View();
        }
        public ActionResult SimpleTable()
        {
            var sorgu = from x in c.Customers.Where(x=>x.CustomerStatus==true)
                        group x by x.CustomerCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }
        public ActionResult Partial1()
        {
            var sorgu = from x in c.Personels.Where(x => x.PersonelStatus==true)
                        group x by x.Department.DepartmentName into g
                        select new GroupClass2
                        {
                            DepartmentId = g.Key,
                            Number = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }
        public ActionResult Partial2()
        {
            var deger = c.Customers.Where(x => x.CustomerStatus == true);
            return PartialView(deger);
        }
        public ActionResult Partial3()
        {
            var deger = c.Products.Include(x=>x.Category).ToList();
            return PartialView(deger);
        }
        public ActionResult Partial4()
        {
            var sorgu = from x in c.Products
                        group x by x.Marka into g
                        select new GroupClass3
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }
    }
}