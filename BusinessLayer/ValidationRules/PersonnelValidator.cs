using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PersonnelValidator : AbstractValidator<Personnel>
    {
        public PersonnelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad boş olamaz!");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Soyad 3 karakterden az olamaz!");
            RuleFor(x => x.SurName).MaximumLength(20).WithMessage("Soyad 20 karakterden fazla olamaz!");
            RuleFor(x => x.CompanyID).NotEmpty().WithMessage("Şirket boş olamaz!");
            RuleFor(x => x.ManagerID).NotEmpty().WithMessage("Yönetici boş olamaz!");
        }
    }
}
