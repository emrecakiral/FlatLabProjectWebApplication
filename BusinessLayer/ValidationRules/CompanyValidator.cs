using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Başlık boş olamaz!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("İçerik boş olamaz!");
            RuleFor(x => x.CompanyTitle).NotEmpty().WithMessage("Personel boş olamaz!");
        }
    }
}
