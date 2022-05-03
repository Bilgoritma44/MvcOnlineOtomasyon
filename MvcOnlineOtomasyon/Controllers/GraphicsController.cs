using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class GraphicsController : Controller
    {
        Context c = new Context();
        // GET: Graphics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuc = c.Products.ToList();
            sonuc.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuc.ToList().ForEach(y => yvalue.Add(y.Stock));

            var grafik = new Chart(width: 800, height: 800);

            grafik.AddTitle("Ürün Stok Sayısı").AddLegend("Stok").AddSeries(chartType:"Pie",name:"Değerler", xValue: xvalue, yValues: yvalue).Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            return View();
        } 
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<ChartClass> ProductList()
        {
            List<ChartClass> chrt = new List<ChartClass>();
            using(var c=new Context())
            {
                chrt = c.Products.Select(x => new ChartClass
                {
                    ChartProductName = x.ProductName,
                    ChartStock = x.Stock
                }).ToList();
            }
            return chrt;
        }
    }
}