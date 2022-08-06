using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public Manager GetByID(int id)
        {
            return _managerDal.Get(x => x.ManagerID == id);
        }

        public Manager GetByMail(string mail)
        {
            return _managerDal.Get(x => x.MailAddress == mail);
        }

        public List<Manager> GetList()
        {
            return _managerDal.List();
        }

        public void ManagerAdd(Manager manager)
        {
            _managerDal.Insert(manager);
        }

        public void ManagerDelete(Manager manager)
        {
            _managerDal.Delete(manager);
        }

        public void ManagerUpdate(Manager manager)
        {
            _managerDal.Update(manager);
        }
    }
}
