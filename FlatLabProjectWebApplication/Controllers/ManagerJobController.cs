using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [Authorize(Roles = "Manager")]
    public class ManagerJobController : Controller
    {

        JobManager jm = new JobManager(new EfJobDal());
        PersonnelManager pm = new PersonnelManager(new EfPersonnelDal());
        public ActionResult Index()
        {
            var jobvalues = jm.GetList();
            return View(jobvalues);
        }


        [HttpGet]
        public ActionResult AddJob()
        {
        //    List<SelectListItem> personnels = (from x in pm.GetList()
        //                                       select new SelectListItem
        //                                       {
        //                                           Text = x.
        //                                       }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(Job item)
        {
            JobValidator jobvalidator = new JobValidator();
            ValidationResult results = jobvalidator.Validate(item);
            if (results.IsValid)
            {
                jm.JobAdd(item);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteJob(int id)
        {
            var jobvalue = jm.GetByID(id);
            jm.JobDelete(jobvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditJob(int id)
        {
            var jobvalue = jm.GetByID(id);
            return View(jobvalue);
        }


        [HttpPost]
        public ActionResult EditJob(Job id)
        {
            jm.JobUpdate(id);
            return RedirectToAction("Index");
        }
    }
}