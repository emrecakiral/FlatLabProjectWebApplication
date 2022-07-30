using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IJobService
    {
        IJobDal _jobdal;

        public JobManager(IJobDal jobdal)
        {
            _jobdal = jobdal;
        }

        public void JobDelete(Job job)
        {
            _jobdal.Delete(job);
        }

        public Job GetByID(int id)
        {
            return _jobdal.Get(x => x.JobID == id);
        }

        public List<Job> GetList()
        {
            return _jobdal.List();
        }

        public void JobAdd(Job job)
        {
            _jobdal.Insert(job);
        }

        public void JobUpdate(Job job)
        {
            _jobdal.Update(job);
        }
    }
}
