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

namespace FlatLabProjectWebApplication.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        readonly ManagerManager mm = new ManagerManager(new EfManagerDal());
        readonly CompanyManager cm = new CompanyManager(new EfCompanyDal());

        public ActionResult Index()
        {
            var managervalues = mm.GetList();
            return View(managervalues);
        }



        [HttpGet]
        public ActionResult AddManager()
        {
            ViewBag.companies = cm.GetCompanyListItem();
            return View();
        }

        [HttpPost]
        public ActionResult AddManager(Manager item)
        {
            ViewBag.companies = cm.GetCompanyListItem();
            ManagerValidator managerValidator = new ManagerValidator();
            ValidationResult result = managerValidator.Validate(item);
            if (result.IsValid)
            {
                mm.ManagerAdd(item);
                return RedirectToAction("Index", "Manager");
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



        [HttpGet]
        public ActionResult EditManager(int id)
        {
            var managervalue = mm.GetByID(id);
            ViewBag.companies = cm.GetCompanyListItem();
            return View(managervalue);
        }

        [HttpPost]
        public ActionResult EditManager(Manager item)
        {
            ViewBag.companies = cm.GetCompanyListItem();

            ManagerValidator managerValidator = new ManagerValidator();
            ValidationResult result = managerValidator.Validate(item);
            if (result.IsValid)
            {
                mm.ManagerUpdate(item);
                return RedirectToAction("Index", "Manager");
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



        public ActionResult DeleteManager(int id)
        {
            var managervalue = mm.GetByID(id);
            mm.ManagerDelete(managervalue);
            return RedirectToAction("Index", "Manager");
        }
    }
}