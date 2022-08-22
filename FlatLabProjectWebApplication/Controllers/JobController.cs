using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using System.Data.Entity;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize(Roles = "Manager , Personnel")]
    public class JobController : Controller
    {
        PersonnelManager pm = new PersonnelManager(new EfPersonnelDal());
        ManagerManager mm = new ManagerManager(new EfManagerDal());
        JobManager jm = new JobManager(new EfJobDal());
        Context c = new Context();
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
            List<Personnel> selectedList = new List<Personnel>();

            var save = c.Entry(item);
            save.State = EntityState.Added;

            JobValidator jobValidator = new JobValidator();
            ValidationResult result = jobValidator.Validate(item);
            if (result.IsValid)
            {
                jm.JobAdd(item);
                save.State = EntityState.Modified;
                save.Collection(i => i.Personnels).Load();
                item.Personnels.Clear();

                foreach (var pers in item.PersonnelsIDs)
                {
                    var perResult = c.Personnels.Find(pers);
                    item.Personnels.Add(perResult);
                }
                c.SaveChanges();
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