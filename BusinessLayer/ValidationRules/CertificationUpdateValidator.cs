using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CertificationUpdateValidator : AbstractValidator<Certification>
    {
        public CertificationUpdateValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(1, int.MaxValue).WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Sertifika alanı boş geçilemez");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Sertifika alanı en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Sertifika alanı en fazla 250 karakterden oluşmalıdır");
        }
    }
}
