using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonnelService
    {
        List<Personnel> GetList();
        List<Personnel> GetListByID(int id);
        void PersonnelAdd(Personnel personnel);
        void PersonnelDelete(Personnel personnel);
        void PersonnelUpdate(Personnel personnel);
        Personnel GetById(int id);
    }
}
