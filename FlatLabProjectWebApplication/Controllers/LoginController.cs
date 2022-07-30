using DataAccessLayer.Concrete;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace FlatLabProjectWebApplication.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Personnel o)
        {
            Context c = new Context();

            Personnel perinfo = c.Personnels.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);

            Manager maninfo = c.Managers.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);

            Admin admininfo = c.Admins.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);

            if (perinfo != null)
            {
                FormsAuthentication.SetAuthCookie(perinfo.UserName, false);
                FormsAuthentication.SetAuthCookie(perinfo.MailAddress, false);
                Session["UserName"] = perinfo.UserName;
                Session["MailAddress"] = perinfo.MailAddress;
                return RedirectToAction("Index", "Home");
            }
            else if (maninfo != null)
            {
                FormsAuthentication.SetAuthCookie(maninfo.UserName, false);
                FormsAuthentication.SetAuthCookie(maninfo.MailAddress, false);
                Session["UserName"] = maninfo.UserName;
                Session["MailAddress"] = maninfo.MailAddress;
                return RedirectToAction("Index", "Home");
            }
            else if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                FormsAuthentication.SetAuthCookie(admininfo.MailAddress, false);
                Session["UserName"] = admininfo.UserName;
                Session["MailAddress"] = admininfo.MailAddress;
                return RedirectToAction("Index", "Admin");

            }

            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}