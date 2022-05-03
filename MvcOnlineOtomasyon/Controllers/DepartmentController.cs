using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var deger = c.Departments.Where(x=>x.Status==true).ToList();
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Departments.Find(id);
            deger.Status = false;
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department p)
        {
            p.Status = true;
            c.Departments.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger = c.Personels.Where(x => x.DepartmentId == id).ToList();
            var deger2 = c.Departments.Find(id);
            ViewBag.v1 = deger2.DepartmentName;
            return View(deger);
        }
        public ActionResult Update(int id)
        {
            var deger = c.Departments.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Department p)
        {
            Department department = c.Departments.Where(x => x.DepartmentId == p.DepartmentId).SingleOrDefault();
            department.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSales(int id)
        {
            var deger = c.SalesMoves.Where(x => x.PersonelId == id).ToList();
            var deger2 = c.Personels.Find(id);
            ViewBag.v1 = deger2.PersonelName +" "+ deger2.PersonelLastName;
            ViewBag.v2 = deger2.DepartmentId;
            return View(deger);
        }
    }
}