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
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık 5 karakterden kısa olamaz!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık 50 karakterden uzun olamaz!");

            RuleFor(x => x.Contents).NotEmpty().WithMessage("İçerik boş olamaz!");
            RuleFor(x => x.Contents).MinimumLength(30).WithMessage("İçerik 30 karakterden kısa olamaz!");
            RuleFor(x => x.Contents).MaximumLength(1000).WithMessage("İçerik 1000 karakterden uzun olamaz!");

            RuleFor(x => x.Personnels).NotEmpty().WithMessage("Personeller boş olamaz!");

            RuleFor(x => x.ManagerID).NotEmpty().WithMessage("Manager ID boş olamaz!");

            RuleFor(x => x.CompletionDate).NotEmpty().WithMessage("Bitirme tarihi boş olamaz!");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Durum boş olamaz!");

            RuleFor(x => x.Priority).NotEmpty().WithMessage("Öncelik seviyesi boş olamaz!");

            RuleFor(x => x.CompletionDate).NotEmpty().WithMessage("Bitirme tarihi boş olamaz!");
        }
    }
}
