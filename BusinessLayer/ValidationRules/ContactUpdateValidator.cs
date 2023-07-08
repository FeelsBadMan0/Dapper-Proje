using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactUpdateValidator : AbstractValidator<Contact>
    {
        public ContactUpdateValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(1, int.MaxValue).WithMessage("ID alanı boş geçilemez");

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.");
            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("Ad Soyad alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("Ad Soyad alanı en fazla 50 karakterden oluşmalıdır.");


            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");

            RuleFor(x => x.Mail).MinimumLength(15).WithMessage("Mail alanı en az 15 karakterden oluşmalıdır.");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail alanı en fazla 50 karakterden oluşmalıdır.");


            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu alanı en fazla 100 karakterden oluşmalıdır.");


            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez.");

            RuleFor(x => x.Message).MinimumLength(15).WithMessage("Mesaj alanı en az 15 karakterden oluşmalıdır.");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("Mesaj alanı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
