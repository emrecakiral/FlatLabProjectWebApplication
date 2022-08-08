using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatLabProjectWebApplication.Controllers
{
    public class NotificationsController : Controller
    {
        MailManager mm = new MailManager(new EfMailDal());
        public PartialViewResult Notification()
        {
            string receiverMail = User.Identity.Name;
            var mailvalues = mm.GetListInbox(receiverMail);
            ViewBag.mailCount = mailvalues.Count();
            return PartialView(mailvalues);
        }

        public PartialViewResult Tasks()
        {

            return PartialView();
        }
    }
}