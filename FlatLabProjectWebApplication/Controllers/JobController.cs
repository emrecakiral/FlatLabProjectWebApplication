using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        PersonnelManager pm = new PersonnelManager(new EfPersonnelDal());
        ManagerManager mm = new ManagerManager(new EfManagerDal());
        JobManager jm = new JobManager(new EfJobDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetJobList()
        {
            var jobvalues = jm.GetList();
            return View(jobvalues);
        }


        public ActionResult AddJob()
        {
            Manager manager = mm.GetByMail(User.Identity.Name);
            List<Personnel> perList = pm.GetListByManagerID(manager.ManagerID);

            List<SelectListItem> personnels = (from x in perList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.UserName,
                                                   Value = x.PersonnelID.ToString(),
                                                   Selected = true
                                               }).ToList();
            ViewBag.personnelList = personnels;

            var types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Yok", Value = 1.ToString(), Selected = true });
            types.Add(new SelectListItem() { Text = "Normal", Value = 2.ToString() });
            types.Add(new SelectListItem() { Text = "Öncelikli", Value = 3.ToString() });
            types.Add(new SelectListItem() { Text = "Acil", Value = 4.ToString() });


            ViewBag.Priority = types;
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(Job item)
        {
            Manager manager = mm.GetByMail(User.Identity.Name);
            item.CreationDate = DateTime.Now;
            item.Status = true;
            item.ManagerID = manager.ManagerID;
            JobValidator jobValidator = new JobValidator();
            ValidationResult result = jobValidator.Validate(item);
            if (result.IsValid)
            {
                jm.JobAdd(item);
                return RedirectToAction("GetJobList", "Job");
            }
            else
            {
                foreach (var j in result.Errors)
                {
                    List<Personnel> perList = pm.GetListByManagerID(manager.ManagerID);
                    List<SelectListItem> personnels = (from x in perList
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name + " " + x.UserName,
                                                           Value = x.PersonnelID.ToString(),
                                                           Selected = true
                                                       }).ToList();
                    ViewBag.personnelList = personnels;

                    var types = new List<SelectListItem>();
                    types.Add(new SelectListItem() { Text = "Yok", Value = 1.ToString(), Selected = true });
                    types.Add(new SelectListItem() { Text = "Normal", Value = 2.ToString() });
                    types.Add(new SelectListItem() { Text = "Öncelikli", Value = 3.ToString() });
                    types.Add(new SelectListItem() { Text = "Acil", Value = 4.ToString() });
                    ViewBag.Priority = types;
                    ModelState.AddModelError(j.PropertyName, j.ErrorMessage);
                }
            }
            return View();
        }
    }
}