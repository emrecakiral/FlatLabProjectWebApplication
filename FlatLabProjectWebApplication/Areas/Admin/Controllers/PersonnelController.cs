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

    public class PersonnelController : Controller
    {
        readonly PersonnelManager pm = new PersonnelManager(new EfPersonnelDal());
        readonly CompanyManager cm = new CompanyManager(new EfCompanyDal());
        readonly ManagerManager mm = new ManagerManager(new EfManagerDal());
        public ActionResult Index()
        {
            var PersonelValues = pm.GetList();
            return View(PersonelValues);
        }


        [HttpGet]
        public ActionResult AddPersonnel()
        {
            IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ManagerID.ToString()

                                                        }).ToList();
            ViewBag.managers = managervalue;

            ViewBag.companies = cm.GetCompanyListItem();
            return View();
        }
        [HttpPost]
        public ActionResult AddPersonnel(Personnel item)
        {
            IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ManagerID.ToString()

                                                        }).ToList();
            ViewBag.managers = managervalue;

            ViewBag.companies = cm.GetCompanyListItem();
            PersonnelValidator personnelvalidator = new PersonnelValidator();
            ValidationResult result = personnelvalidator.Validate(item);
            if (result.IsValid)
            {
                pm.PersonnelAdd(item);
                return RedirectToAction("Index", "Personnel");
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
        [Authorize(Roles = "Admin, Personnel")]
        public ActionResult EditPersonnel(int id)
        {
            Personnel perValue = pm.GetById(id);
            IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ManagerID.ToString()

                                                        }).ToList();
            ViewBag.managers = managervalue;
            ViewBag.companies = cm.GetCompanyListItem();
            return View(perValue);
        }
        [HttpPost]
        public ActionResult EditPersonnel(Personnel item)
        {
            ViewBag.companies = cm.GetCompanyListItem();
            PersonnelValidator personnelValidator = new PersonnelValidator();
            ValidationResult result = personnelValidator.Validate(item);
            if (result.IsValid)
            {
                pm.PersonnelUpdate(item);
                return RedirectToAction("Index", "Personnel");
            }
            else
            {
                foreach (var j in result.Errors)
                {
                    ModelState.AddModelError(j.PropertyName, j.ErrorMessage);
                    IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                                select new SelectListItem
                                                                {
                                                                    Text = x.Name,
                                                                    Value = x.ManagerID.ToString()

                                                                }).ToList();
                    ViewBag.managers = managervalue;
                }
            }
            return View();
        }
    }
}