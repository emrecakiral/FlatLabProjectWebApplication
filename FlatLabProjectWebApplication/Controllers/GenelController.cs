using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize]
    public abstract class GenelController : Controller
    {
        MailManager mm = new MailManager(new EfMailDal());
        Context c = new Context();
        public GenelController()
        {
            string receiverMail = (string)TempData["InboxCount"];
            var userinfo = c.Personnels.Where(x => x.MailAddress == receiverMail).Select(y => y.MailAddress).FirstOrDefault();
            if (userinfo == null)
                userinfo = c.Managers.Where(x => x.MailAddress == receiverMail).Select(y => y.MailAddress).FirstOrDefault();
            var mailvalues = mm.GetListInbox(userinfo).OrderByDescending(x => x.Date).ToList();
            TempData["InboxCount"] = mailvalues.Count();
        }
    }
}