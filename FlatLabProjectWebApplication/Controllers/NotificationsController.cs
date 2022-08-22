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
    [Authorize]
    public class NotificationsController : Controller
    {
        MailManager mm = new MailManager(new EfMailDal());
        public PartialViewResult Notification()
        {
            if (Session["UserName"] == null)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            string receiverMail = User.Identity.Name;
            var mailvalues = mm.GetListInbox(receiverMail);
            ViewBag.mailCount = mailvalues.Count();
            return PartialView(mailvalues);
        }
    }
}