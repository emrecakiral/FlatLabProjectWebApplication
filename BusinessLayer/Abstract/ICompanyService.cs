using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetList();
        void CompanyAdd(Company company);
        Company GetByID(int id);
        void CompanyDelete(Company company);
        void CompanyUpdate(Company company);
    }
}
