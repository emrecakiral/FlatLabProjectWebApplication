using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ManagerValidator: AbstractValidator<Manager>
    {
        public ManagerValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage("Mail adresi boş olamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim boş olamaz!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz!");
            RuleFor(x => x.CompanyID).NotEmpty().WithMessage("Şirket boş olamaz!");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Rol boş olamaz!");
        }
    }
}
