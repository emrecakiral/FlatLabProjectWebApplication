using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize]
    public class MailController : Controller
    {

        MailManager mm = new MailManager(new EfMailDal());
        MailValidator mv = new MailValidator();
        public ActionResult Inbox()
        {
            string receiverMail = (string)Session["MailAddress"];
            var mailvalues = mm.GetListInbox(receiverMail);
            TempData["InboxCount"] = mailvalues.Count();
            return View(mailvalues);
        }

        public ActionResult Sendbox()
        {
            string senderMail = (string)Session["MailAddress"];
            var mailvalues = mm.GetSendInbox(senderMail);
            TempData["SendBoxCount"] = mailvalues.Count();
            return View(mailvalues);
        }

        public ActionResult NewMail()
        {
            var types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Aciliyet Durumu", Value = "0" });
            types.Add(new SelectListItem() { Text = "Önemsiz", Value = "1" });
            types.Add(new SelectListItem() { Text = "Öncelikli", Value = "2" });
            types.Add(new SelectListItem() { Text = "Acil", Value = "3" });

            ViewBag.ItemTypes = types;
            return View();
        }
        [HttpPost]
        public ActionResult NewMail(Mail mail)
        {
            ValidationResult result = mv.Validate(mail);
            if (result.IsValid)
            {
                mail.SenderMail = Session["MailAddress"].ToString();
                mail.Date = DateTime.Now;
                mm.MailAdd(mail);
                return RedirectToAction("Sendbox");
            }
            else
            {
                var types = new List<SelectListItem>();
                types.Add(new SelectListItem() { Text = "Aciliyet Durumu", Value = "0" });
                types.Add(new SelectListItem() { Text = "Önemsiz", Value = "1" });
                types.Add(new SelectListItem() { Text = "Öncelikli", Value = "2" });
                types.Add(new SelectListItem() { Text = "Acil", Value = "3" });

                ViewBag.ItemTypes = types;
                foreach (var j in result.Errors)
                {
                    ModelState.AddModelError(j.PropertyName, j.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetMailDetails(int id)
        {
            var mailvalues = mm.GetByID(id);
            return View(mailvalues);
        }

        [Authorize]
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public PartialViewResult SearchMail(string searchVal)
        {
            string receiverMail = (string)Session["MailAddress"];
            var mailvalues = mm.GetListInbox(receiverMail);

            var resultSearch = new List<Mail>();
            if (!string.IsNullOrWhiteSpace(searchVal))
                if (searchVal.Length >= 3)
                    resultSearch = mm.FindByCriter(c => c.Subject.ToLower().Contains(searchVal.ToLower()));

            return PartialView(resultSearch.ToList());
        }
    }
}