using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MailValidator : AbstractValidator<Mail>
    {
        public MailValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş olamaz!");
            RuleFor(x => x.Message).MinimumLength(30).WithMessage("Mesaj 30 karakterden kısa olamaz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık boş olamaz!");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı boş olamaz!");
        }
    }
}
