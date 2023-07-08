using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SkillUpdateValidator : AbstractValidator<Skill>
    {
        public SkillUpdateValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(1, int.MaxValue).WithMessage("ID alanı boş geçilemez");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Yetenek alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Yetenek alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Yetenek alanı en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
