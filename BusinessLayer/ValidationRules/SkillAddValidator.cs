using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SkillAddValidator : AbstractValidator<Skill>
    {
        public SkillAddValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Yetenek alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Yetenek alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Yetenek alanı en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
