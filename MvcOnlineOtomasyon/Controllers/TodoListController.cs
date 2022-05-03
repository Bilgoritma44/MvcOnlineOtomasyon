using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class TodoListController : Controller
    {
        Context c = new Context();
        // GET: TodoList
        public ActionResult Index()
        {
            var d1 = c.Customers.Count();
            ViewBag.v1 = d1;
            var d2 = c.Products.Count();
            ViewBag.v2 = d2;
            var d3 = c.Categories.Count();
            ViewBag.v3 = d3;
            var d4 = c.Customers.Select(x => x.CustomerCity).Distinct().Count();
            ViewBag.v4 = d4;

            var deger = c.TodoLists.ToList();
            return View(deger);
        }
    }
}