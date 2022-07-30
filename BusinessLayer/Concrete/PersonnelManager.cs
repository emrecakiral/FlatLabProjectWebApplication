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
    public class PersonnelManager : IPersonnelService
    {
        IPersonnelDal _personnelDal;

        public PersonnelManager(IPersonnelDal personelDal)
        {
            _personnelDal = personelDal;
        }

        public Personnel GetById(int id)
        {
            return _personnelDal.Get(x=> x.PersonnelID == id);
        }

        public Personnel GetByUserName(string username)
        {
            return _personnelDal.Get(x => x.UserName == username);
        }

        public List<Personnel> GetList()
        {
            return _personnelDal.List();
        }

        public List<Personnel> GetListByID(int id)
        {
            return _personnelDal.List(x => x.Manager.ManagerID == id);
        }

        public void PersonnelAdd(Personnel personnel)
        {
            _personnelDal.Insert(personnel);
        }

        public void PersonnelDelete(Personnel personnel)
        {
            _personnelDal.Delete(personnel);
        }

        public void PersonnelUpdate(Personnel personnel)
        {
            _personnelDal.Update(personnel);
        }
    }
}
