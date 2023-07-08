using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class InterestAddValidator : AbstractValidator<Interest>
    {
        public InterestAddValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Hobi alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Hobi alanı en az 20 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Hobi alanı en fazla 500 karakterden oluşmalıdır.");
        }
    }
}
