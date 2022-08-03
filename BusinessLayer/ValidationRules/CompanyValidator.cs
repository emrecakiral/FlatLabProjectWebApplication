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
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş olamaz!");
            RuleFor(x => x.CompanyTitle).NotEmpty().WithMessage("Ünvan boş olamaz!");
        }
    }
}
