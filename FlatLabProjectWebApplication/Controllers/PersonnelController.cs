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
    //[Authorize]
    public class PersonnelController : Controller
    {
        PersonnelManager pm = new PersonnelManager(new EfPersonnelDal());
        PersonnelValidator personnelvalidator = new PersonnelValidator();
        public ActionResult Index()
        {
            var PersonelValues = pm.GetList();
            return View(PersonelValues);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddPersonnel()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddPersonnel(Personnel p )
        {
            ValidationResult results = personnelvalidator.Validate(p);
            if (results.IsValid)
            {
                pm.PersonnelAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditPersonnel()
        {
            string userName = (string)Session["UserName"];
            Personnel personnel = pm.GetByUserName(userName);
            return View(personnel);
        }
        [HttpPost]
        public ActionResult EditPersonnel(Personnel p)
        {
            string userName = (string)Session["UserName"];
            Personnel personnel = pm.GetByUserName(userName);
            p.Company = personnel.Company;
            p.Jobs = personnel.Jobs;
            p.Manager = personnel.Manager;
            p.Role = personnel.Role;
            ValidationResult results = personnelvalidator.Validate(p);
            if (results.IsValid)
            {
                pm.PersonnelUpdate(p);
                return RedirectToAction("/Home");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}