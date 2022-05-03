using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        // GET: Category
        public ActionResult Index(int page=1)
        {
            
            var deger = c.Categories.ToList().ToPagedList(page, 3);
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category p)
        {
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Categories.Find(id);
            c.Categories.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Categories.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Category p)
        {
            Category category = c.Categories.Where(x => x.CategoryId == p.CategoryId).SingleOrDefault();
            category.CategoryName = p.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}