using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize(Roles = "Manager , Personnel")]
    public class HomeController : Controller
    {
        MailManager mm = new MailManager(new EfMailDal());
        public ActionResult Index()
        {
            string receiverMail = User.Identity.Name;
            var mailvalues = mm.GetListInbox(receiverMail);
            ViewBag.mailCount = mailvalues.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}