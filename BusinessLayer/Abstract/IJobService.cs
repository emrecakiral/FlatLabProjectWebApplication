using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobService
    {
        List<Job> GetList();
        void JobAdd(Job job);
        Job GetByID(int id);
        void JobDelete(Job job);
        void JobUpdate(Job job);
    }
}
