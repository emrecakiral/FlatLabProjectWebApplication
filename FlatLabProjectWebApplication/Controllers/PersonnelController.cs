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
        public ActionResult AddPersonnel(Personnel item )
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
            IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ManagerID.ToString()

                                                        }).ToList();
            ViewBag.managers = managervalue;
            //string userName = (string)Session["UserName"];
            //Personnel personnel = pm.GetByUserName(userName);
            //return View(personnel); personelin kendi controllerı içindir

            var personnelvalue = pm.GetById(id);
            ViewBag.companies = cm.GetCompanyListItem();
            return View(personnelvalue);
        }
        [HttpPost]
        public ActionResult EditPersonnel(Personnel item)
        {
            IEnumerable<SelectListItem> managervalue = (from x in mm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ManagerID.ToString()

                                                        }).ToList();
            ViewBag.managers = managervalue;

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
                }
            }
            return View();




            //_layout için

            //string userName = (string)Session["UserName"];
            //Personnel personnel = pm.GetByUserName(userName);
            //p.Company = personnel.Company;
            //p.Jobs = personnel.Jobs;
            //p.Manager = personnel.Manager;
            //p.Role = personnel.Role;
            //ValidationResult results = personnelvalidator.Validate(p);
            //if (results.IsValid)
            //{
            //    pm.PersonnelUpdate(p);
            //    return RedirectToAction("Index","Personnel");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
        }
    }
}