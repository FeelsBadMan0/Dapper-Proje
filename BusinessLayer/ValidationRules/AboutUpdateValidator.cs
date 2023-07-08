using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutUpdateValidator : AbstractValidator<About>
    {
        public AboutUpdateValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(1, int.MaxValue).WithMessage("ID alanı boş geçilemez");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad alanı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ad alanı en fazla 30 karakterden oluşmalıdır.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyad alanı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyad alanı en fazla 30 karakterden oluşmalıdır.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez.");
            RuleFor(x => x.Address).MinimumLength(10).WithMessage("Adres alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Address).MaximumLength(100).WithMessage("Adres alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
            RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("Telefon alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.PhoneNumber).MaximumLength(20).WithMessage("Telefon alanı en fazla 20 karakterden oluşmalıdır.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Mail alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail alanı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama alanı en fazla 1000 karakterden oluşmalıdır.");
        }
    }
}
