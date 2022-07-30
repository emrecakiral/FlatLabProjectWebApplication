using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManagerService
    {
        List<Manager> GetList();
        void ManagerAdd(Manager manager);
        Manager GetByID(int id);
        void ManagerDelete(Manager manager);
        void ManagerUpdate(Manager manager);
    }
}
