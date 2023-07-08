using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class EducationUpdateValidator : AbstractValidator<Education>
    {
        public EducationUpdateValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(1, int.MaxValue).WithMessage("ID alanı boş geçilemez");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Okul alanı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Okul alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Okul alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Fakülte alanı boş geçilemez.");
            RuleFor(x => x.SubTitle).MinimumLength(10).WithMessage("Fakülte alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.SubTitle).MaximumLength(100).WithMessage("Fakülte alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Bölüm alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Bölüm alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Bölüm alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.GNOT).NotEmpty().WithMessage("GNOT alanı boş geçilemez.");
            RuleFor(x => x.GNOT).MinimumLength(3).WithMessage("GNOT alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.GNOT).MaximumLength(10).WithMessage("GNOT alanı en fazla 10 karakterden oluşmalıdır.");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(x => x.Date).MinimumLength(4).WithMessage("Tarih alanı en az 4 karakterden oluşmalıdır.");
            RuleFor(x => x.Date).MaximumLength(100).WithMessage("Tarih alanı en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
