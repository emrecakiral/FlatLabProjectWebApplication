using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x=> x.Title).NotEmpty().WithMessage("Başlık boş olamaz!");
            RuleFor(x => x.Contents).NotEmpty().WithMessage("İçerik boş olamaz!");
            RuleFor(x => x.Personnels).NotEmpty().WithMessage("Personel boş olamaz!");
        }
    }
}
