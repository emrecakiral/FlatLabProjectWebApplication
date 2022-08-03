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
    }
}