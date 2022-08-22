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
        public ActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Manager", new { area = "Admin" });
                else
                    return RedirectToAction("Index", "Home");
            }
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Personnel o)
        {
            string rUrl = (string)TempData["returnUrl"];
            Context c = new Context();
            object user = new object();

            user = c.Personnels.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);
            if (user == null)
                user = c.Managers.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);
            if (user == null)
                user = c.Admins.FirstOrDefault(x => x.UserName == o.UserName && x.Password == o.Password);

            IHuman userPer = (IHuman)user;
            FormsAuthentication.SetAuthCookie(userPer.MailAddress, false);
            Session["UserName"] = userPer.UserName;
            Session["Image"] = userPer.Image;
            Session["FullName"] = userPer.Name + " " + userPer.SurName;

            if (rUrl != null)
                return Redirect(rUrl);
            else
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Manager", new { area = "Admin" });
                else
                    return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}