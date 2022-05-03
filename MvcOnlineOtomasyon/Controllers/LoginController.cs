using MvcOnlineOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Register(Customer p)
        {
            p.CustomerStatus = true;
            c.Customers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer p)
        {
            var bilgi = c.Customers.FirstOrDefault(x => x.CustomerMail == p.CustomerMail && x.CustomerPassword == p.CustomerPassword);
            
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.CustomerMail, false);
                Session["CustomerMail"] = bilgi.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Username, false);
                Session["Username"] = bilgi.Username.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }
    }
}