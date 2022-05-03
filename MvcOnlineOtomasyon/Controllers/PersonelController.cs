using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var deger = c.Personels.Where(x=>x.PersonelStatus==true).ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            List<SelectListItem> departman = (from x in c.Departments.ToList()

                                              select new SelectListItem
                                              {
                                                  Text=x.DepartmentName,
                                                  Value=x.DepartmentId.ToString()

                                              }).ToList();

            ViewBag.v1 = departman;

            return View();
        }
        [HttpPost]
        public ActionResult Add(Personel p)
        {
            if(Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string url = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Gallery/" + fileName + url;

                Request.Files[0].SaveAs(Server.MapPath(path));
                p.PersonelPhoto = "/Gallery/" + fileName + url;
            }

            p.PersonelStatus = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Personels.Find(id);
            deger.PersonelStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> departman = (from x in c.Departments.ToList()

                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmentName,
                                                  Value = x.DepartmentId.ToString()

                                              }).ToList();

            ViewBag.v1 = departman;

            var deger = c.Personels.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Personel p)
        {

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string url = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Gallery/" + fileName + url;

                Request.Files[0].SaveAs(Server.MapPath(path));
                p.PersonelPhoto = "/Gallery/" + fileName + url;
            }

            Personel personel = c.Personels.Where(x => x.PersonelId == p.PersonelId).SingleOrDefault();
            personel.PersonelName = p.PersonelName;
            personel.PersonelLastName = p.PersonelLastName;
            personel.PersonelPhoto = p.PersonelPhoto;
            personel.DepartmentId = p.DepartmentId;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger = c.SalesMoves.Where(x => x.PersonelId == id).ToList();
            var deger2 = c.Personels.Find(id);
            ViewBag.v1 = deger2.PersonelName + " " + deger2.PersonelLastName;
            return View(deger);
        }
        public ActionResult PersonelDetail()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }
        
    }
}