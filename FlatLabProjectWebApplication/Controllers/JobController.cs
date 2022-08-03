using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace FlatLabProjectWebApplication.Controllers
{
    //[Authorize]
    public class JobController : Controller
    {
        // GET: Job
        JobManager jm = new JobManager(new EfJobDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetJobList(int id)
        {
            var jobvalues = jm.GetList();
            return View(jobvalues);
        }

        public ActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(Job item)
        {
            JobValidator jobValidator = new JobValidator();
            ValidationResult result = jobValidator.Validate(item);
            if (result.IsValid)
            {
                jm.JobAdd(item);
                return RedirectToAction("GetJobList");
            }
            else
            {
                foreach (var j in result.Errors)
                {
                    ModelState.AddModelError(j.PropertyName, j.ErrorMessage);
                }
            }
            return View();
        }
    }
}