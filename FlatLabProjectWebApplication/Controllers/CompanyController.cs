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
    public class CompanyController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        public ActionResult Index()
        {
            var companyvalues = cm.GetList();
            return View(companyvalues);
        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company item)
        {
            CompanyValidator companyValidator = new CompanyValidator();
            ValidationResult result = companyValidator.Validate(item);
            if (result.IsValid)
            {
                cm.CompanyAdd(item);
                return RedirectToAction("Index", "Company");
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
        public ActionResult EditCompany(int id)
        {
            var companyvalue = cm.GetByID(id);
            return View(companyvalue);
        }
        [HttpPost]
        public ActionResult EditCompany(Company item)
        {
            CompanyValidator companyValidator = new CompanyValidator();
            ValidationResult result = companyValidator.Validate(item);
            if (result.IsValid)
            {
                cm.CompanyUpdate(item);
                return RedirectToAction("Index", "Company");
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

        public ActionResult DeleteCompany(int id)
        {
            // todo: task var mı kontrol edilecek
            var companyvalue = cm.GetByID(id);
            cm.CompanyDelete(companyvalue);
            return RedirectToAction("Index", "Company");
        }
    }
}