﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;


        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void CompanyAdd(Company company)
        {
            _companyDal.Insert(company);
        }

        public void CompanyDelete(Company company)
        {
            _companyDal.Delete(company);
        }

        public List<SelectListItem> GetCompanyListItem()
        {
            return (from x in _companyDal.List()
                    select new SelectListItem
                    {
                        Text = x.CompanyTitle,
                        Value = x.CompanyID.ToString()

                    }).ToList();
        }

        public void CompanyUpdate(Company company)
        {
            _companyDal.Update(company);
        }

        public Company GetByID(int id)
        {
            return _companyDal.Get(x => x.CompanyID == id);
        }

        public List<Company> GetList()
        {
            return _companyDal.List();
        }
    }
}
