using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatLabProjectWebApplication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        
        
        public ActionResult Index()
        {
            ManagerManager mm = new ManagerManager(new EfManagerDal());
            var managervalues = mm.GetList();
            return View(managervalues);
        }


        [HttpGet]
        public ActionResult AddManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddManager(Manager m)
        {
            ManagerManager mm = new ManagerManager(new EfManagerDal());
            mm.ManagerAdd(m);
            return RedirectToAction("/Admin");
        }
    }
}